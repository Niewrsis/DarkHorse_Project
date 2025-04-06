using System;
using TMPro;
using UnityEngine;

namespace BarSystem
{

    public class OrdersView : MonoBehaviour
    {
        [SerializeField] private Transform gridGroupObj;
        [SerializeField] private GameObject textToClone;

        // —сылка на CurrentOrder, чтобы подписатьс€ на событие OnOrderChanged
        [SerializeField] private CurrentOrder currentOrder;

        private void OnEnable()
        {
            if (currentOrder != null)
            {
                currentOrder.OnOrderChanged.AddListener(UpdateOrderDisplay);
            }
            else
            {
                Debug.LogError("CurrentOrder is not assigned in OrdersView!");
            }
        }

        private void OnDisable()
        {
            if (currentOrder != null)
            {
                currentOrder.OnOrderChanged.RemoveListener(UpdateOrderDisplay);
            }
        }

        private void ClearOrderDisplay()
        {
            foreach (Transform child in gridGroupObj.transform)
            {
                Destroy(child.gameObject);
            }
        }

        // UpdateOrderDisplay принимает List<OrderTypeSlot> напр€мую.
        public void UpdateOrderDisplay()
        {
            if (currentOrder == null || currentOrder.Order == null)
            {
                Debug.LogError("CurrentOrder is null or Order list is null!");
                return;
            }

            ClearOrderDisplay();

            foreach (var order in currentOrder.Order)
            {
                GameObject text = Instantiate(textToClone, gridGroupObj);
                text.GetComponent<TextMeshProUGUI>().text = $"{order.Count}x {Enum.GetName(typeof(OrderType), order.OrderType)}";
            }
        }
    }
}
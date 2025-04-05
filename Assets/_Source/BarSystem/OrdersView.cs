using Core;
using System;
using TMPro;
using UnityEngine;

namespace BarSystem
{
    public class OrdersView : MonoBehaviour
    {
        [SerializeField] private Transform gridGroupObj;
        [SerializeField] private GameObject textToClone;

        [SerializeField] private GameObject orderObj;

        private CurrentOrder _currentOrder;

        public EventManager EventHandler = new();

        private void Start()
        {
            Instantiate(orderObj);

            _currentOrder = FindFirstObjectByType<CurrentOrder>();

            DrawOrders();
        }
        private void OnEnable()
        {
            EventHandler.OnComplete += RemoveOrders;
        }
        private void OnDisable()
        {
            EventHandler.OnComplete -= RemoveOrders;
        }
        private void RemoveOrders()
        {
            foreach (Transform child in gridGroupObj.transform)
            {
                Destroy(child.gameObject);
            }

            _currentOrder = FindFirstObjectByType<CurrentOrder>();

            DrawOrders();
        }
        private void DrawOrders()
        {
            for(int i = 0; _currentOrder.Order.Count > i; i++)
            {
                GameObject text = Instantiate(textToClone, gridGroupObj);
                text.GetComponent<TextMeshProUGUI>().text = $"{_currentOrder.Order[i].Count}x {Enum.GetName(typeof(OrderType), _currentOrder.Order[i].OrderType)}";
            }
        }
    }
}
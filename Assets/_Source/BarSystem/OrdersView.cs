using System;
using TMPro;
using UnityEngine;

namespace BarSystem
{
    public class OrdersView : MonoBehaviour
    {
        [SerializeField] private Transform gridGroupObj;
        [SerializeField] private GameObject textToClone;

        private CurrentOrder _currentOrder;

        private void Start()
        {
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
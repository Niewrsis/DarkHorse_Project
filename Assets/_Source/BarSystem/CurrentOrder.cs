using System.Collections.Generic;
using UnityEngine;

namespace BarSystem
{
    public class CurrentOrder : MonoBehaviour
    {
        public List<OrderTypeSlot> Order;

        private OrderGeneration _orderGeneration = new();

        private void Awake()
        {
            Order = _orderGeneration.Generate();

            foreach(OrderTypeSlot v in Order)
            {
                Debug.Log($"{v.OrderType}, {v.Count}");
            }
        }
    }
}

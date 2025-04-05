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
            //DontDestroyOnLoad(this);
            Order = _orderGeneration.Generate();
        }

        public void RegenerateOrders()
        {
            Instantiate(gameObject);
            Destroy(gameObject);
        }
    }
}

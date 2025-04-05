using Core;
using System.Collections.Generic;
using UnityEngine;

namespace BarSystem
{
    public class CurrentOrder : MonoBehaviour
    {
        public List<OrderTypeSlot> Order;

        private OrderGeneration _orderGeneration = new();

        private OrdersView _eventManager;

        private void Awake()
        {
            _eventManager = FindFirstObjectByType<OrdersView>();

            DontDestroyOnLoad(this);
            Order = _orderGeneration.Generate();

            _eventManager.EventHandler.OnComplete += RegenerateOrders;
        }

        public void RegenerateOrders()
        {
            GameObject obj = Instantiate(gameObject);
            obj.name = "Orders";
            Destroy(gameObject);
        }
        private void OnDestroy()
        {
            _eventManager.EventHandler.OnComplete -= RegenerateOrders;
        }
    }
}

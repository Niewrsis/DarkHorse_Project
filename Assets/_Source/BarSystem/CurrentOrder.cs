using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace BarSystem
{
    public class CurrentOrder : MonoBehaviour
    {
        public List<OrderTypeSlot> Order { get; private set; }

        private IOrderService _orderService;

        public UnityEvent OnOrderChanged;

        public void Initialize(IOrderService orderService)
        {
            _orderService = orderService;
            GenerateNewOrder();
        }

        public void GenerateNewOrder()
        {
            Order = _orderService.GenerateNewOrder();
            foreach (var slot in Order)
            {
                slot.CompletedCount = 0;
            }
            OnOrderChanged?.Invoke();
        }

        public void CompleteOrder(OrderType orderType)
        {
            var slotToComplete = Order.FirstOrDefault(slot => slot.OrderType == orderType && slot.CompletedCount < slot.Count);

            if (slotToComplete != null)
            {
                slotToComplete.CompletedCount++;
                OnOrderChanged?.Invoke();
            }
            else
            {
                Debug.LogWarning($"No matching and uncompleted order found for {orderType}");
            }
        }
    }
}
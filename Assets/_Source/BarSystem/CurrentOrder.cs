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
            List<OrderTypeSlot> newOrder = _orderService.GenerateNewOrder();

            // Preserve the completed status of existing orders
            if (Order != null && Order.Count > 0 && newOrder != null) // Add check for null
            {
                foreach (var newSlot in newOrder)
                {
                    var existingSlot = Order.FirstOrDefault(slot => slot.OrderType == newSlot.OrderType);
                    if (existingSlot != null)
                    {
                        newSlot.CompletedCount = existingSlot.CompletedCount; // Copy progress
                    }
                }
            }

            if (newOrder != null) // Add null check
            {
                Order = newOrder;
                OnOrderChanged?.Invoke();
            }
            else
            {
                Debug.LogWarning("GenerateNewOrder returned null. No order generated.");
            }
        }

        // Method to mark an order as completed
        public void CompleteOrder(OrderType orderType)
        {
            // Find the first matching order that is not already completed
            var slotToComplete = Order.FirstOrDefault(slot => slot.OrderType == orderType && slot.CompletedCount < slot.Count);

            if (slotToComplete != null)
            {
                slotToComplete.CompletedCount++;  // Increment the completed count
                OnOrderChanged?.Invoke(); // Update UI after completing an order
            }
            else
            {
                Debug.LogWarning($"No matching and uncompleted order found for {orderType}");
            }
        }
    }
}
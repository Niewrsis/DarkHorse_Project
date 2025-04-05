using System;
using System.Collections.Generic;
using UnityEngine;

namespace BarSystem
{
    public class OrderGeneration
    {
        private List<OrderTypeSlot> _order = new List<OrderTypeSlot>();
        public List<OrderTypeSlot> Generate()
        {
            System.Random rnd = new System.Random();
            int orderCount = rnd.Next(1, 4);
            int maxAttempts = 10;

            for (int i = 0; i < orderCount; i++)
            {
                OrderTypeSlot newOrder;
                int attempts = 0;
                do
                {
                    newOrder = GenerateSlot();
                    attempts++;
                    if (attempts > maxAttempts)
                    {
                        Debug.LogWarning("Не удалось создать уникальный заказ после " + maxAttempts + " попыток.  Пропускаем.");
                        break; // Прекращаем попытки
                    }
                } while (isOrderRepeated(newOrder));

                if (attempts <= maxAttempts) // Добавляем только если успешно сгенерировали
                    _order.Add(newOrder);
            }
            return _order;
        }

        private OrderTypeSlot GenerateSlot()
        {
            System.Random rnd = new System.Random();
            OrderType orderType = (OrderType)rnd.Next(0, 3);
            int orderAmount = rnd.Next(1, 3);

            OrderTypeSlot slot = new OrderTypeSlot();
            slot.OrderType = orderType;
            slot.Count = orderAmount;
            return slot;
        }
        private bool isOrderRepeated(OrderTypeSlot newOrder)
        {
            foreach (OrderTypeSlot v in _order)
            {
                if (newOrder.OrderType == v.OrderType)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

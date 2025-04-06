using System.Collections.Generic;
using UnityEngine;

namespace BarSystem
{
    public class OrderGeneration : IOrderService
    {
        public List<FoodTypeDataSO> AvailableFoodTypes; // Ссылка на список Scriptable Objects

        private readonly List<OrderTypeSlot> _order = new List<OrderTypeSlot>();
        private readonly System.Random _rnd = new System.Random();

        public List<OrderTypeSlot> GenerateNewOrder() // Реализуем интерфейс IOrderService
        {
            _order.Clear();

            int orderCount = _rnd.Next(1, 4);
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
                        break;
                    }
                } while (isOrderRepeated(newOrder));

                if (attempts <= maxAttempts && newOrder != null) // Проверяем, что newOrder не null
                    _order.Add(newOrder);
            }
            return _order;
        }

        private OrderTypeSlot GenerateSlot()
        {
            FoodTypeDataSO foodTypeData = AvailableFoodTypes[_rnd.Next(0, AvailableFoodTypes.Count)];
            int orderAmount = _rnd.Next(1, 3);

            // ADD THIS CHECK
            if (orderAmount <= 0) // Проверяем, что количество больше 0
            {
                return null; // Если количество 0, возвращаем null
            }

            OrderTypeSlot slot = new OrderTypeSlot();
            slot.OrderType = foodTypeData.OrderType;
            slot.Count = orderAmount;
            return slot;
        }

        private bool isOrderRepeated(OrderTypeSlot newOrder)
        {
            if (newOrder == null) // Добавляем проверку на null
            {
                return false; // Если заказ null, то он не повторяется
            }

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
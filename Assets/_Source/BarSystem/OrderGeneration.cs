using System.Collections.Generic;
using UnityEngine;

namespace BarSystem
{
    public class OrderGeneration
    {
        public List<FoodTypeDataSO> AvailableFoodTypes; // Ссылка на список Scriptable Objects

        private readonly List<OrderTypeSlot> _order = new List<OrderTypeSlot>();
        private readonly System.Random _rnd = new System.Random();

        public List<OrderTypeSlot> Generate()
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

                if (attempts <= maxAttempts)
                    _order.Add(newOrder);
            }
            return _order;
        }

        private OrderTypeSlot GenerateSlot()
        {
            FoodTypeDataSO foodTypeData = AvailableFoodTypes[_rnd.Next(0, AvailableFoodTypes.Count)];
            int orderAmount = _rnd.Next(1, 3);

            OrderTypeSlot slot = new OrderTypeSlot();
            slot.OrderType = foodTypeData.OrderType;
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
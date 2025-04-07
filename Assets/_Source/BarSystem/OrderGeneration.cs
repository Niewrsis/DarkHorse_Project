using System;
using System.Collections.Generic;
using UnityEngine;

namespace BarSystem
{
    public class OrderGeneration
    {
        private List<FoodTypeDataSO> _availableFoodTypes;
        private OrderSO _orderSO;

        private readonly List<OrderTypeSlot> _order = new List<OrderTypeSlot>();
        private readonly System.Random _rnd = new System.Random();

        public OrderGeneration(List<FoodTypeDataSO> availableFoodTypes, OrderSO orderSO)
        {
            _availableFoodTypes = availableFoodTypes;
            _orderSO = orderSO;
        }
        public void GenerateNewOrder()
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
                } while (IsOrderRepeated(newOrder));

                if (attempts <= maxAttempts && newOrder != null)
                    _order.Add(newOrder);
            }

            _orderSO.SetNewOrder(_order);
        }

        private OrderTypeSlot GenerateSlot()
        {
            FoodTypeDataSO foodTypeData = _availableFoodTypes[_rnd.Next(0, _availableFoodTypes.Count)];
            int orderAmount = _rnd.Next(1, 3);

            if (orderAmount <= 0)
            {
                return null;
            }

            OrderTypeSlot slot = new OrderTypeSlot();
            slot.OrderType = foodTypeData.OrderType;
            slot.Count = orderAmount;
            return slot;
        }

        private bool IsOrderRepeated(OrderTypeSlot newOrder)
        {
            if (newOrder == null)  return false;

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
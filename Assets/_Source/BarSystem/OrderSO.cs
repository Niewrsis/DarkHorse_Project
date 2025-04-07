using System;
using System.Collections.Generic;
using UnityEngine;

namespace BarSystem
{
    [CreateAssetMenu(fileName = "OrderSO", menuName = "SO/OrderSO")]
    public class OrderSO : ScriptableObject
    {
        [Header("Settings")]
        public bool IsFirstGeneration;

        [Header("Orders")]
        public OrderTypeSlot Cocktail;
        public OrderTypeSlot Beer;
        public OrderTypeSlot Salad;

        public bool IsEverythingCompleted()
        {
            if (Cocktail.IsCompleted && Beer.IsCompleted && Salad.IsCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddCompleteOrder(OrderType orderType)
        {
            Debug.Log($"Called type - {Enum.GetName(typeof(OrderType), orderType)}");
            switch (orderType)
            {
                case OrderType.Cocktail:
                    {
                        Cocktail.CompletedCount++;
                        break;
                    }
                case OrderType.Beer:
                    {
                        Beer.CompletedCount++;
                        break;
                    }
                case OrderType.Salad:
                    {
                        Salad.CompletedCount++;
                        break;
                    }
                default:
                    {
                        Debug.Log("OrderType was not found");
                        break;
                    }
            }
        }
        public List<OrderTypeSlot> GetAllFirstSpawnedOrders()
        {
            List<OrderTypeSlot> list = new List<OrderTypeSlot>();
            if (Cocktail.IsSpawnedAsFirst)
            {
                list.Add(Cocktail);
            }

            if (Beer.IsSpawnedAsFirst)
            {
                list.Add(Beer);
            }

            if (Salad.IsSpawnedAsFirst)
            {
                list.Add(Salad);
            }
            return list;
        }
        public void SetNewOrder(List<OrderTypeSlot> order)
        {
            ResetOrder();

            foreach (OrderTypeSlot slot in order)
            {
                switch (slot.OrderType)
                {
                    case OrderType.Cocktail:
                        {
                            Cocktail.Count = slot.Count;
                            Cocktail.IsSpawnedAsFirst = true;
                            break;
                        }
                    case OrderType.Beer:
                        {
                            Beer.Count = slot.Count;
                            Beer.IsSpawnedAsFirst = true;
                            break;
                        }
                    case OrderType.Salad:
                        {
                            Salad.Count = slot.Count;
                            Salad.IsSpawnedAsFirst = true;
                            break;
                        }
                    default:
                        {
                            Debug.LogError("Set new order error");
                            break;
                        }
                }
            }
        }
        private void ResetOrder()
        {
            Cocktail.Count = 0;
            Cocktail.CompletedCount = 0;
            Cocktail.IsSpawnedAsFirst = false;

            Beer.Count = 0;
            Beer.CompletedCount = 0;
            Beer.IsSpawnedAsFirst = false;

            Salad.Count = 0;
            Salad.CompletedCount = 0;
            Salad.IsSpawnedAsFirst = false;
        }
    }
}
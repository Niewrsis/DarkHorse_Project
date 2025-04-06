using BarSystem;
using MiniGamesSystem;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public CurrentOrder currentOrder;
        public OrdersView ordersView;

        public List<FoodTypeDataSO> AvailableFoodTypes;

        void Start()
        {
            OrderGeneration orderGeneration = new OrderGeneration();
            orderGeneration.AvailableFoodTypes = AvailableFoodTypes;

            OrderService orderService = new OrderService(orderGeneration);
            currentOrder.Initialize(orderService);

            if (MiniGameResult.CompletedOrderType != OrderType.None)
            {
                if (MiniGameResult.IsSuccess)
                {
                    currentOrder.CompleteOrder(MiniGameResult.CompletedOrderType);
                }
                MiniGameResult.CompletedOrderType = OrderType.None;
                MiniGameResult.IsSuccess = false;
            }
        }
    }
}
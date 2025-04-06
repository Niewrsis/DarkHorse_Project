using BarSystem;
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

            ordersView.UpdateOrderDisplay();
        }
    }
}
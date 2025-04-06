using System.Collections.Generic;

namespace BarSystem
{
    public class OrderService : IOrderService
    {
        private readonly OrderGeneration _orderGeneration;

        public OrderService(OrderGeneration orderGeneration)
        {
            _orderGeneration = orderGeneration;
        }

        public List<OrderTypeSlot> GenerateNewOrder()
        {
            return _orderGeneration.Generate();
        }
    }
}
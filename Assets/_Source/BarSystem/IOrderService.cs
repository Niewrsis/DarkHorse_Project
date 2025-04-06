using System.Collections.Generic;

namespace BarSystem
{
    public interface IOrderService
    {
        List<OrderTypeSlot> GenerateNewOrder();
    }
}
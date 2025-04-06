using BarSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        Order = _orderService.GenerateNewOrder();
        OnOrderChanged?.Invoke();
    }
}
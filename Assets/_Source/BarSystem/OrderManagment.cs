using System.Collections.Generic;
using UnityEngine;

namespace BarSystem
{
    public class OrderManagment : MonoBehaviour
    {
        [SerializeField] private OrderSO orderSO;
        [SerializeField] private List<FoodTypeDataSO> availableFoodTypes;

        private OrderGeneration _orderGeneration;

        private void Awake()
        {
            _orderGeneration = new(availableFoodTypes, orderSO);

            if (orderSO.IsEverythingCompleted())
            {
                _orderGeneration.GenerateNewOrder();
            }
            if (orderSO.IsFirstGeneration)
            {
                _orderGeneration.GenerateNewOrder();
                orderSO.IsFirstGeneration = false;
            }
        }
    }
}
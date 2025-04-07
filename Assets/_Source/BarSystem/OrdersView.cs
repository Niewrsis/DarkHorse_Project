using System;
using TMPro;
using UnityEngine;

namespace BarSystem
{
    public class OrdersView : MonoBehaviour
    {
        [SerializeField] private GameObject objForSpawn;
        [SerializeField] private GameObject orderPrefab;

        [SerializeField] private OrderSO orderSO;

        private void Start()
        {
            foreach(OrderTypeSlot slot in orderSO.GetAllFirstSpawnedOrders())
            {
                TextMeshProUGUI textObj = Instantiate(orderPrefab, objForSpawn.transform).GetComponentInChildren<TextMeshProUGUI>();

                if(!slot.IsCompleted)
                {
                    textObj.text = $"{Enum.GetName(typeof(OrderType), slot.OrderType)} : {slot.Count - slot.CompletedCount}";
                }
                else
                {
                    textObj.fontStyle = FontStyles.Strikethrough;
                    textObj.text = $"{Enum.GetName(typeof(OrderType), slot.OrderType)} : 0";
                }
            }
        }
    }
}
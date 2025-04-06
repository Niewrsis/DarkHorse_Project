using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BarSystem
{
    public class OrdersView : MonoBehaviour
    {
        public CurrentOrder currentOrder;
        public GameObject orderItemPrefab;
        public Transform orderContainer;

        private List<GameObject> orderItems = new List<GameObject>();

        public void UpdateUI()
        {
            foreach (Transform child in orderContainer)
            {
                Destroy(child.gameObject);
            }
            orderItems.Clear();

            if (currentOrder != null && currentOrder.Order != null)
            {
                foreach (var slot in currentOrder.Order)
                {
                    Debug.Log($"OrderType: {slot.OrderType}, Count: {slot.Count}, CompletedCount: 0");

                    GameObject orderItem = Instantiate(orderItemPrefab, orderContainer);
                    orderItems.Add(orderItem);

                    TextMeshProUGUI orderTypeText = orderItem.GetComponentInChildren<TextMeshProUGUI>();


                    orderTypeText.rectTransform.sizeDelta = new Vector2(200, 50); // Установите ширину и высоту
                    orderTypeText.rectTransform.anchoredPosition = Vector2.zero; // Установите позицию
                    orderTypeText.fontSize = 36;
                    orderTypeText.color = Color.black;
                    // Set the text
                    orderTypeText.text = $"{slot.OrderType}: {slot.Count}";
                }
            }
            else
            {
                Debug.Log("currentOrder is null or currentOrder.Order is null");
            }
        }
    }
}
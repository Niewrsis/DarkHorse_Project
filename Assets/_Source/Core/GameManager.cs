using BarSystem;
using MiniGamesSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; } // Singleton instance

        public CurrentOrder currentOrder;
        public OrdersView ordersView;

        public List<FoodTypeDataSO> AvailableFoodTypes; // Assign in inspector

        private OrderService orderService; // Make it a field

        void Awake()
        {
            // Singleton pattern implementation
            if (Instance != null && Instance != this)
            {
                Destroy(this); // Destroy duplicate instances
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Persist this object between scene loads
            }
        }

        void Start()
        {
            // Initialize OrderService only once
            OrderGeneration orderGeneration = new OrderGeneration();
            orderGeneration.AvailableFoodTypes = AvailableFoodTypes;
            orderService = new OrderService(orderGeneration);

            // Initialize CurrentOrder with OrderService
            currentOrder.Initialize(orderService);

            // Check if a mini-game was just completed
            if (MiniGameResult.CompletedOrderType != OrderType.None)
            {
                // If minigame was success
                if (MiniGameResult.IsSuccess)
                {
                    // Mark the order as completed
                    currentOrder.CompleteOrder(MiniGameResult.CompletedOrderType);
                }

                // Reset the result so it's not processed again
                MiniGameResult.CompletedOrderType = OrderType.None;
                MiniGameResult.IsSuccess = false;
            }

            // Make sure we are only generating orders on scene start and not on return
            if (currentOrder.Order == null || currentOrder.Order.Count == 0)
            {
                currentOrder.GenerateNewOrder();
            }

            // Manually update the UI after generating the order
            ordersView.UpdateUI();
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
        }

        // Make sure to unsubscribe when the object is destroyed
        private void OnDestroy()
        {
        }
    }
}
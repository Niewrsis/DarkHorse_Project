using BarSystem;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGamesSystem
{
    public class MiniGameController : MonoBehaviour
    {
        public OrderType orderType;

        public void OnMiniGameCompleted(bool isSuccess)
        {
            MiniGameResult.CompletedOrderType = orderType;
            MiniGameResult.IsSuccess = isSuccess;

            FoodTypeDataSO foodTypeData = GetFoodTypeData(orderType);

            if (foodTypeData != null)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.LogError("FoodTypeData not found for " + orderType);
            }

        }
        FoodTypeDataSO GetFoodTypeData(OrderType orderType)
        {
            GameManager gameManager = GameManager.Instance;

            if (gameManager != null)
            {
                return gameManager.AvailableFoodTypes.Find(data => data.OrderType == orderType);
            }

            Debug.LogError("GameManager not found in the scene!");
            return null;
        }
    }
}
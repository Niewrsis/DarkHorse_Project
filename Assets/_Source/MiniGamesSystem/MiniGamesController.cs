using BarSystem;
using MiniGamesSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGamesSystem
{
    public class MiniGameController : MonoBehaviour
    {
        public OrderType orderType; // Укажите тип заказа для этой мини-игры в Inspector

        public void OnMiniGameCompleted(bool isSuccess) // Вызывается после завершения мини-игры (например, кнопкой)
        {
            // 1. Устанавливаем результат мини-игры (тип выполненного заказа)
            MiniGameResult.CompletedOrderType = orderType;
            MiniGameResult.IsSuccess = isSuccess;

            // 2. Загружаем основную сцену
            SceneManager.LoadScene("BarScene"); // Replace "BarScene" with your main scene name
        }
    }
}
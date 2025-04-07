using BarSystem;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGamesSystem
{
    public class MiniGameController : MonoBehaviour
    {
        [SerializeField] private OrderType orderType;
        [SerializeField] private OrderSO OrderSO;

        public void OnMiniGameCompleted()
        {
            OrderSO.AddCompleteOrder(orderType);

            SceneManager.LoadScene(1);

        }
    }
}
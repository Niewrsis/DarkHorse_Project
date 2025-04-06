using BarSystem;
using MiniGamesSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGamesSystem
{
    public class MiniGameController : MonoBehaviour
    {
        public OrderType orderType; // ������� ��� ������ ��� ���� ����-���� � Inspector

        public void OnMiniGameCompleted(bool isSuccess) // ���������� ����� ���������� ����-���� (��������, �������)
        {
            // 1. ������������� ��������� ����-���� (��� ������������ ������)
            MiniGameResult.CompletedOrderType = orderType;
            MiniGameResult.IsSuccess = isSuccess;

            // 2. ��������� �������� �����
            SceneManager.LoadScene(0); // Replace "BarScene" with your main scene name
        }
    }
}
using BarSystem;
using MindSystem;
using SceneSystem;
using System.Collections;
using TMPro;
using UnityEngine;

namespace TimerSystem
{
    public class ClientTimer : MonoBehaviour
    {
        [SerializeField] private int maximumTimeInSeconds;
        private int _currentTime;

        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private OrderSO orderSO;
        [SerializeField] private MindControll mindControll;
        [SerializeField] private ClientManager clientManager;

        public Sprite CurrentSprite;
        public bool IsNewClient;

        private void Start()
        {
            _currentTime = maximumTimeInSeconds;
            StartCoroutine(StartTimer());
            UpdateUI();
        }

        private IEnumerator StartTimer()
        {
            IsNewClient = true;
            clientManager.ChangeClient();
            while (_currentTime > 0)
            {
                yield return new WaitForSeconds(1);
                _currentTime--;
                UpdateUI();
            }
            OnLose();
            ResetTimer();
        }

        public void ResetTimer()
        {
            StopCoroutine(StartTimer());
            _currentTime = maximumTimeInSeconds;
            StartCoroutine(StartTimer());
            UpdateUI();
        }

        private void UpdateUI()
        {
            timerText.text = FormattingToTime(_currentTime);
            TryGetFirstObj();
        }

        private string FormattingToTime(int time)
        {
            int minutes = time / 60;
            int seconds = time % 60;
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void OnLose()
        {
            _currentTime = maximumTimeInSeconds;
            orderSO.IsFirstGeneration = true;
            mindControll.DecreaseMind();
            UpdateUI();
        }
        private bool TryGetFirstObj()
        {
            if (FindFirstObjectByType<ClientManager>() == null)
            {
                return false;
            }
            else
            {
                clientManager = FindFirstObjectByType<ClientManager>();
                return true;
            }
        }
    }
}

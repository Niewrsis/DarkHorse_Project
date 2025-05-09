using SceneSystem;
using System;
using TimerSystem;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MindSystem
{
    public class MindControll : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI mindText;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private Button restartButton;

        private int _currentMind;

        [SerializeField] private int increasingInPercent;
        [SerializeField] private int decreasingPercent;
        [SerializeField] private Button button;

        public Action OnMind;

        private void Start()
        {
            _currentMind = 100;
            restartButton.onClick.AddListener(RestartGame);
            losePanel.SetActive(false);
        }

        public void IncreaseMind()
        {
            _currentMind += increasingInPercent;
            if (_currentMind > 100)
            {
                _currentMind = 100;
            }
            FindAnyObjectByType<ClientTimer>().ResetTimer();
            UpdateUI();
        }

        public void DecreaseMind()
        {
            _currentMind -= decreasingPercent;
            if (_currentMind <= 0)
            {
                _currentMind = 0;
                OnLose();
            }
            UpdateUI();
        }

        private void OnLose()
        {
            losePanel.SetActive(true);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void UpdateUI()
        {
            mindText.text = _currentMind + "%";
        }
    }
}

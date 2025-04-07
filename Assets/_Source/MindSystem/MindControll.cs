using System;
using TimerSystem;
using TMPro;
using UnityEngine;

namespace MindSystem
{
    public class MindControll : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI mindText;

        private int _currentMind;

        [SerializeField] private int increasingInPercent;
        [SerializeField] private int decreasingPercent;

        public Action OnMind;

        private void Start()
        {
            _currentMind = 100;
        }
        public void IncreaseMind()
        {
            _currentMind += increasingInPercent;
            if(_currentMind > 100)
            {
                _currentMind = 100;
            }
            FindAnyObjectByType<ClientTimer>().ResetTimer();
            UpdateUI();
        }
        public void DecreaseMind()
        {
            _currentMind -= decreasingPercent;
            if( _currentMind <= 0)
            {
                Debug.Log(_currentMind);
                _currentMind = 0;
                OnLose();
            }
            UpdateUI();
        }
        private void OnLose()
        {
            Debug.Log("Lose");
        }
        private void UpdateUI()
        {
            mindText.text = _currentMind + "%";
        }
    }
}
using SceneSystem;
using System;
using System.Collections;
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

        private int _currentMind;

        public Image loseImage;
        public GameObject otherGameObject;

        [SerializeField] private int increasingInPercent;
        [SerializeField] private int decreasingPercent;
        [SerializeField] private Button button;

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
                _currentMind = 0;
                OnLose();
            }
            UpdateUI();
        }
        private void OnLose()
        {
            otherGameObject.gameObject.SetActive(false);
            loseImage.gameObject.SetActive(true);
            StartCoroutine(WaitAndLoadScene(5f));
        }

        private IEnumerator WaitAndLoadScene(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(6);
        }
        private void UpdateUI()
        {
            mindText.text = _currentMind + "%";
        }
    }
}
using DialogSystem;
using System.Collections;
using TMPro;
using UnityEngine;

namespace TimerSystem
{
    public class GlobalTimer : MonoBehaviour
    {
        [SerializeField] private int maximumTimeInSeconds;
        [SerializeField] private DialogueTimer dialogueTimer;
        [SerializeField] private ClientManager clientManager;
        private int _currentTime;

        [SerializeField] private TextMeshProUGUI timerText;

        private void Awake()
        {
            GlobalTimer[] timers = FindObjectsOfType<GlobalTimer>();
            if (timers.Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
                _currentTime = maximumTimeInSeconds;
                StartCoroutine(StartTimer());
                UpdateUI();
            }
        }

        private IEnumerator StartTimer()
        {
            while (_currentTime > 0)
            {
                yield return new WaitForSeconds(1);
                _currentTime--;
                UpdateUI();
            }
            dialogueTimer.OnTimerEnds?.Invoke();
            clientManager.ShowHiddenImage();
        }

        private void UpdateUI()
        {
            timerText.text = FormattingToTime(_currentTime);
        }

        private string FormattingToTime(int time)
        {
            int minutes = time / 60;
            int seconds = time % 60;
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void SelfDestruction()
        {
            Destroy(gameObject);
        }
    }
}

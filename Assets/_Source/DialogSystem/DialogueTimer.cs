using SceneSystem;
using System;
using System.Collections.Generic;
using TimerSystem;
using UnityEngine;

namespace DialogSystem
{

    public class DialogueTimer : MonoBehaviour
    {
        public DaySO CurrentDay;
        public List<DaySO> AllAvailableDays;
        public float Delay = 5f; // Time in seconds before the dialogue starts

        public Action OnTimerEnds;

        private bool dialogueStarted = false;

        void Start()
        {
            OnTimerEnds += StartDialogueAfterDelay;
        }

        private void StartDialogueAfterDelay()
        {
            StartDialogue();
            dialogueStarted = true;
        }

        public void StartDialogue()
        {
            Debug.Log(PlayerPrefs.GetInt(ConstVar.DAYS_PP));
            switch (PlayerPrefs.GetInt(ConstVar.DAYS_PP))
            {
                case 1:
                    {
                        DialogueManager.Instance.StartDialogue(AllAvailableDays[0]);
                        break;
                    }
                case 2:
                    {
                        DialogueManager.Instance.StartDialogue(AllAvailableDays[1]);
                        break;
                    }
                case 3:
                    {
                        DialogueManager.Instance.StartDialogue(AllAvailableDays[2]);
                        break;
                    }
                case 4:
                    {
                        DialogueManager.Instance.StartDialogue(AllAvailableDays[3]);
                        break;
                    }
                default:
                    {
                        Debug.Log("Error to load day");
                        break;
                    }
            }
        }
        public void SwitchSceneToBasement(int index)
        {
            Destroy(FindFirstObjectByType<GlobalTimer>());
            SceneChanger.ChangeScene(index);
        }
        private void OnDisable()
        {
            OnTimerEnds -= StartDialogueAfterDelay;
        }
    }

}
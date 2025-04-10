using FadeSystem;
using SceneSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using TimerSystem;
using UnityEditor;
using UnityEngine;

namespace DialogSystem
{

    public class DialogueTimer : MonoBehaviour
    {
        public List<DaySO> AllAvailableDays;
        public Action OnTimerEnds;

        void Start()
        {
            OnTimerEnds += StartDialogueAfterDelay;
        }

        private void StartDialogueAfterDelay()
        {
            StartDialogue();
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
            StartCoroutine(Switch(index));
        }
        private IEnumerator Switch(int index)
        {
            yield return new WaitForSeconds(5);
            FindFirstObjectByType<Fade>().FadeIn();
            yield return new WaitForSeconds(2);
            if (PlayerPrefs.GetInt(ConstVar.DAYS_PP) == 5)
            {
                SceneChanger.ChangeScene(6);
            }
            else
            {
                SceneChanger.ChangeScene(index);
            }
        }
        private void OnDisable()
        {
            OnTimerEnds -= StartDialogueAfterDelay;
        }
    }

}
using SceneSystem;
using System;
using System.Collections;
using TimerSystem;
using UnityEngine;

namespace DialogSystem
{

    public class DialogueTimer : MonoBehaviour
    {
        public DaySO DayToLoad;
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

        private void StartDialogue()
        {
            if (DayToLoad != null)
            {
                DialogueManager.Instance.StartDialogue(DayToLoad);
            }
            else
            {
                Debug.LogError("DaySO is not assigned on DialogueTimer!");
            }
        }
        public void SwitchSceneToBasement()
        {
            Destroy(FindFirstObjectByType<GlobalTimer>());
            SceneChanger.ChangeScene(ConstVar.BASEMENT_SCREEN_INDEX);
        }
        private void OnDisable()
        {
            OnTimerEnds -= StartDialogueAfterDelay;
        }
    }

}
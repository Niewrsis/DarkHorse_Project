using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogueActivator : MonoBehaviour
    {
        public DaySO DayToLoad;
        public Button DialogueButton; // Assign the UI Button here.
        public UnityEvent OnDialogueActivated; //Event to call if you want to do something else
        public UnityEvent OnDialogueEnded;

        void Start()
        {
            //Make sure the button is assigned
            if (DialogueButton == null)
            {
                Debug.LogError("DialogueButton is not assigned on DialogueActivator!");
                enabled = false; //Disable this script if we have no button
                return;
            }
            // Add a listener to the button that calls the StartDialogue method.
            DialogueButton.onClick.AddListener(StartDialogue);
        }

        public void StartDialogue()
        {
            if (DayToLoad != null)
            {
                OnDialogueActivated?.Invoke();
                DialogueManager.Instance.StartDialogue(DayToLoad);
                DisableButton(); // Disable button after start
            }
            else
            {
                Debug.LogError("DaySO is not assigned on DialogueActivator!");
            }
        }
        public void EnableDialogueButton()
        {
            Debug.Log("EnableDialogueButton called!");
            DialogueButton.interactable = true;
        }

        //Call this in the DialogueManager to Disable the button
        public void DisableButton()
        {
            DialogueButton.interactable = false;
        }
    }
}

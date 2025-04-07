using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DialogSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        public DialogWindowSlot DialogWindow;
        public float TextSpeed = 0.03f;

        private DaySO currentDay;
        private int currentDialogIndex = 0;
        private bool isTyping = false;

        public UnityEvent OnDialogueStart;
        public UnityEvent OnDialogueEnd;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            if (DialogWindow == null)
            {
                Debug.LogError("DialogueWindowSlot is not assigned in DialogueManager!");
            }
        }

        public void StartDialogue(DaySO day)
        {
            currentDay = day;
            currentDialogIndex = 0;
            OnDialogueStart?.Invoke();
            DialogWindow.gameObject.SetActive(true);
            DisplayNextLine();
        }

        public void DisplayNextLine()
        {
            if (currentDialogIndex >= currentDay.Dialog.Count)
            {
                EndDialogue();
                return;
            }

            SpeakerSlot speakerSlot = currentDay.Dialog[currentDialogIndex];
            DialogWindow.Name.text = speakerSlot.Name;
            StartCoroutine(TypeSentence(speakerSlot.Text));

            if (speakerSlot.IsPause)
            {
                // Optionally pause execution here, waiting for player input
                // For example, you could disable automatic progression and wait for a button press.
            }

            //Check if it's the last dialogue line:
            if (speakerSlot.IsEnd)
            {
                EndDialogue();
                return;
            }

            DialogWindow.ContinueButton.gameObject.SetActive(true); // Enable Continue Button here!
        }

        public void OnContinueButtonPressed()
        {
            if (isTyping)
            {
                StopAllCoroutines();
                DialogWindow.Description.text = currentDay.Dialog[currentDialogIndex].Text;
                isTyping = false;
            }
            currentDialogIndex++;
            DialogWindow.ContinueButton.gameObject.SetActive(false); //Disable continue button here
            DisplayNextLine();
        }

        private IEnumerator TypeSentence(string sentence)
        {
            isTyping = true;
            DialogWindow.Description.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                if (!isTyping) // Check if typing has been interrupted
                {
                    yield break; // Exit the coroutine
                }
                DialogWindow.Description.text += letter;
                yield return new WaitForSeconds(TextSpeed);
            }
            isTyping = false;
        }


        public void EndDialogue()
        {
            OnDialogueEnd?.Invoke();
            DialogWindow.gameObject.SetActive(false);
            currentDay = null;
            currentDialogIndex = 0;
        }
    }
}

using DG.Tweening;
using DialogSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BasementSystem
{
    public class BasementDialogues : MonoBehaviour
    {
        [SerializeField] private BasementEvents events;
        [SerializeField] private DialogueTimer dialogue;

        private void Start()
        {
            events.OnEnterBasement += StartDialogue;
        }
        private void StartDialogue()
        {
            dialogue.StartDialogue();
        }
    }
}
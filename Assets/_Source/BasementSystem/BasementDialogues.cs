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
        public void DoTweenBlackScreen(Image image)
        {
            StartCoroutine(Cor(image));
        }
        private IEnumerator Cor(Image image)
        {
            image.DOFade(1, 2f);
            yield return new WaitForSeconds(2f);
            dialogue.SwitchSceneToBasement(1);
        }
    }
}
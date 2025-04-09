using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FadeSystem
{
    public class Fade : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Animator animator;

        public void FadeIn()
        {
            animator.SetTrigger("FadeIn");
        }
    }
}
using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

namespace BasementSystem
{
    public class BasementController : MonoBehaviour
    {
        [SerializeField] private float enter1Timing;
        [SerializeField] private float enter2Timing;
        [SerializeField] private float enter3Timeing;

        [SerializeField] private GameObject gifEnter1;
        [SerializeField] private GameObject gifEnter2;
        [SerializeField] private GameObject gifEnter3;

        [SerializeField] private GameObject background;

        [SerializeField] private int indexTest;

        [SerializeField] private BasementEvents events;


        private void Awake()
        {
            gifEnter1.SetActive(false);
            gifEnter2.SetActive(false);
            gifEnter3.SetActive(false);
            background.SetActive(false);

            switch (PlayerPrefs.GetInt(ConstVar.DAYS_PP))
            {
                case 1:
                    {
                        gifEnter1.SetActive(true);
                        StartCoroutine(EnterToBasement(gifEnter1, enter1Timing));
                        break;
                    }
                case 2:
                    {
                        gifEnter2.SetActive(true);
                        StartCoroutine(EnterToBasement(gifEnter2, enter2Timing));
                        break;
                    }
                case 3:
                    {
                        gifEnter3.SetActive(true);
                        StartCoroutine(EnterToBasement(gifEnter3, enter3Timeing));
                        break;
                    }
                default:
                    {
                        gifEnter2.SetActive(true);
                        StartCoroutine(EnterToBasement(gifEnter2, enter2Timing));
                        break;
                    }
            }
        }
        private IEnumerator EnterToBasement(GameObject gif, float duration)
        {
            yield return new WaitForSeconds(duration);
            gif.SetActive(false);
            background.SetActive(true);
            events.OnEnterBasement?.Invoke();
        }
    }
}
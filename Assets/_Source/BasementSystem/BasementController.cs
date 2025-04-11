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

        [SerializeField] private VideoPlayer gifEnter1;
        [SerializeField] private VideoPlayer gifEnter2;
        [SerializeField] private VideoPlayer gifEnter3;

        [SerializeField] private GameObject background;

        [SerializeField] private int indexTest;

        [SerializeField] private BasementEvents events;


        private void Awake()
        {
            gifEnter1.gameObject.SetActive(false);
            gifEnter2.gameObject.SetActive(false);
            gifEnter3.gameObject.SetActive(false);
            background.SetActive(false);

            switch (PlayerPrefs.GetInt(ConstVar.DAYS_PP))
            {
                case 1:
                    {
                        gifEnter1.gameObject.SetActive(true);
                        StartCoroutine(EnterToBasement(gifEnter1, gifEnter1.clip.length));
                        break;
                    }
                case 2:
                    {
                        gifEnter2.gameObject.SetActive(true);
                        StartCoroutine(EnterToBasement(gifEnter2, gifEnter1.clip.length));
                        break;
                    }
                case 3:
                    {
                        gifEnter3.gameObject.SetActive(true);
                        StartCoroutine(EnterToBasement(gifEnter3, gifEnter1.clip.length));
                        break;
                    }
                default:
                    {
                        gifEnter2.gameObject.SetActive(true);
                        StartCoroutine(EnterToBasement(gifEnter2, gifEnter1.clip.length));
                        break;
                    }
            }
        }
        private IEnumerator EnterToBasement(VideoPlayer gif, double duration)
        {
            yield return new WaitForSeconds((float)duration);
            gif.gameObject.SetActive(false);
            background.SetActive(true);
            events.OnEnterBasement?.Invoke();
        }
    }
}
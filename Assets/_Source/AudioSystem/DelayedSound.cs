using UnityEngine;
using System.Collections;

public class DelayedSound : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource audioSource;
    public float delayInSeconds = 9f;  // Задержка в секундах

    void Start()
    {
        // Получаем ссылку на AudioSource, если она не задана в инспекторе
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource not found on this GameObject! Please add an AudioSource component.");
                enabled = false;
                return;
            }
        }
        // Проверяем, задан ли звук
        if (sound == null)
        {
            Debug.LogError("Sound clip is not assigned!");
            enabled = false;
            return;
        }
        StartCoroutine(PlaySoundAfterDelay());
    }

    IEnumerator PlaySoundAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        audioSource.PlayOneShot(sound);
    }
}
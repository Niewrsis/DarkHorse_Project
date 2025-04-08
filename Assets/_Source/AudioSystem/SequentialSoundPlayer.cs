using UnityEngine;
using System.Collections;

public class SequentialSoundPlayer : MonoBehaviour
{
    public AudioClip[] sounds;  // Массив звуковых файлов
    public AudioSource audioSource; // Ссылка на компонент AudioSource
    public float delayBetweenSounds = 0.1f; // Задержка между звуками в секундах
    public int numberOfLoops = -1; // Количество повторений цикла. -1 для бесконечного цикла.

    private int currentSoundIndex = 0;
    private int currentLoop = 0;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource not found! Please add an AudioSource component to this GameObject.");
                enabled = false; // Отключаем скрипт, чтобы избежать ошибок
                return;
            }
        }

        if (sounds == null || sounds.Length == 0)
        {
            Debug.LogError("No sounds assigned! Please assign sounds to the 'sounds' array.");
            enabled = false;
            return;
        }

        StartCoroutine(PlaySoundsSequentially());
    }

    IEnumerator PlaySoundsSequentially()
    {
        while (numberOfLoops == -1 || currentLoop < numberOfLoops)
        {
            audioSource.clip = sounds[currentSoundIndex];
            audioSource.Play();

            // Ждем, пока звук не закончится
            yield return new WaitForSeconds(audioSource.clip.length + delayBetweenSounds);

            currentSoundIndex++;

            // Если достигли конца массива звуков, начинаем сначала
            if (currentSoundIndex >= sounds.Length)
            {
                currentSoundIndex = 0;
                currentLoop++;
            }
        }

        Debug.Log("Sound sequence complete!");
    }
}
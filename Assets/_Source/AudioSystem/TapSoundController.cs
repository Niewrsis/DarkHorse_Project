using UnityEngine;
using UnityEngine.UI;

public class TapSoundController : MonoBehaviour
{
    public AudioClip sound; // Звук, который нужно проигрывать
    public AudioSource audioSource; // Компонент AudioSource
    public Button button; // Кнопка
    private bool isPlaying = false; // Флаг, показывающий, проигрывается ли звук в данный момент

    void Start()
    {
        // Получаем ссылку на кнопку, если она не задана в инспекторе
        if (button == null)
        {
            button = GetComponent<Button>();
            if (button == null)
            {
                Debug.LogError("Button not found on this GameObject! Please add a Button component.");
                enabled = false; // Отключаем скрипт, чтобы избежать ошибок
                return;
            }
        }

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

        // Отключаем воспроизведение звука при старте
        audioSource.clip = sound;  // Присваиваем клип
        audioSource.loop = true;   // Ставим в режим повтора
        audioSource.Stop();          // Останавливаем проигрывание

        button.onClick.AddListener(ToggleSound);  // Подписываемся на событие нажатия кнопки
    }

    void ToggleSound()
    {
        if (isPlaying)
        {
            StopSound();
        }
        else
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        audioSource.Play();
        isPlaying = true;
        Debug.Log("Sound started");
    }

    void StopSound()
    {
        audioSource.Stop();
        isPlaying = false;
        Debug.Log("Sound stopped");
    }
}
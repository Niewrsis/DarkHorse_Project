using UnityEngine;
using UnityEngine.UI;

public class TapSoundController : MonoBehaviour
{
    public AudioClip sound; // ����, ������� ����� �����������
    public AudioSource audioSource; // ��������� AudioSource
    public Button button; // ������
    private bool isPlaying = false; // ����, ������������, ������������� �� ���� � ������ ������

    void Start()
    {
        // �������� ������ �� ������, ���� ��� �� ������ � ����������
        if (button == null)
        {
            button = GetComponent<Button>();
            if (button == null)
            {
                Debug.LogError("Button not found on this GameObject! Please add a Button component.");
                enabled = false; // ��������� ������, ����� �������� ������
                return;
            }
        }

        // �������� ������ �� AudioSource, ���� ��� �� ������ � ����������
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
        // ���������, ����� �� ����
        if (sound == null)
        {
            Debug.LogError("Sound clip is not assigned!");
            enabled = false;
            return;
        }

        // ��������� ��������������� ����� ��� ������
        audioSource.clip = sound;  // ����������� ����
        audioSource.loop = true;   // ������ � ����� �������
        audioSource.Stop();          // ������������� ������������

        button.onClick.AddListener(ToggleSound);  // ������������� �� ������� ������� ������
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
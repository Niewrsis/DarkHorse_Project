using UnityEngine;
using System.Collections;

public class DelayedSound : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource audioSource;
    public float delayInSeconds = 9f;  // �������� � ��������

    void Start()
    {
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
        StartCoroutine(PlaySoundAfterDelay());
    }

    IEnumerator PlaySoundAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        audioSource.PlayOneShot(sound);
    }
}
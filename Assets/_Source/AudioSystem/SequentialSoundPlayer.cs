using UnityEngine;
using System.Collections;

public class SequentialSoundPlayer : MonoBehaviour
{
    public AudioClip[] sounds;  // ������ �������� ������
    public AudioSource audioSource; // ������ �� ��������� AudioSource
    public float delayBetweenSounds = 0.1f; // �������� ����� ������� � ��������
    public int numberOfLoops = -1; // ���������� ���������� �����. -1 ��� ������������ �����.

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
                enabled = false; // ��������� ������, ����� �������� ������
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

            // ����, ���� ���� �� ����������
            yield return new WaitForSeconds(audioSource.clip.length + delayBetweenSounds);

            currentSoundIndex++;

            // ���� �������� ����� ������� ������, �������� �������
            if (currentSoundIndex >= sounds.Length)
            {
                currentSoundIndex = 0;
                currentLoop++;
            }
        }

        Debug.Log("Sound sequence complete!");
    }
}
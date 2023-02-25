using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float switchAudioTIme = 2f;
    private Coroutine currentRoutine;

    public void SetAuidoClip(AudioClip clip)
    {
        StartCoroutine(SmoothAudioSwitch(5f, clip));
    }

    private IEnumerator SmoothAudioSwitch(float time, AudioClip clip)
    {
        yield return FadeOut(time);
        yield return FadeIn(time, clip);
    }

    private IEnumerator FadeOut(float time)
    {
        if (currentRoutine != null) StopCoroutine(currentRoutine);
        currentRoutine = StartCoroutine(FadeOutRoutine(time));
        yield return currentRoutine;
    }

    private IEnumerator FadeIn(float time, AudioClip clip)
    {
        if (currentRoutine != null) StopCoroutine(currentRoutine);
        currentRoutine = StartCoroutine(FadeInRoutine(time, clip));
        yield return currentRoutine;
    }

    private IEnumerator FadeInRoutine(float time, AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();

        while (audioSource.volume < 1)
        {
            audioSource.volume += (Time.deltaTime / time) * switchAudioTIme;
            yield return null;
        }
    }

    private IEnumerator FadeOutRoutine(float time)
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= (Time.deltaTime / time) * switchAudioTIme;
            yield return null;
        }
    }
}

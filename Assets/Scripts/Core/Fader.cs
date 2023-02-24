using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Coroutine currentCoroutine = null;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void StartFade()
    {
        StartCoroutine(FadeOutIn(1f));
    }

    public IEnumerator FadeOutIn(float time)
    {
        yield return FadeOut(time);
        yield return FadeIn(time);
    }

    public IEnumerator FadeOut(float time)
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(FadeOutRoutine(time));
        yield return currentCoroutine;
    }

    private IEnumerator FadeOutRoutine(float time)
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }

    public IEnumerator FadeIn(float time)
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(FadeInRoutine(time));
        yield return currentCoroutine;
    }

    private IEnumerator FadeInRoutine(float time)
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }

}


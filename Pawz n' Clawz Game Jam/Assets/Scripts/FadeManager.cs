using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private bool automaticallyFadeInOnSceneLoad;
    private Coroutine fadeCoroutine;
    [SerializeField] private float automaticFadeStartAlpha;
    [SerializeField] private float automaticFadeEndAlpha;
    [SerializeField] private float automaticFadeDuration;
    [SerializeField] private float automaticFadeDelayBeforeFade;

    public GameObject FadeScreen;

    private void Awake()
    {   
        if(automaticallyFadeInOnSceneLoad)
        {
            DoFade(automaticFadeStartAlpha, automaticFadeEndAlpha, automaticFadeDuration, automaticFadeDelayBeforeFade);
        }
        
    }

    public void FadeOut()
    {
        FadeScreen.SetActive(true);
    }

    public void DoFade(float startAlpha, float endAlpha, float duration, float delayBeforeFade)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(AnimateFade(startAlpha, endAlpha, duration, delayBeforeFade));
    }

    private IEnumerator AnimateFade (float startAlpha, float endAlpha, float duration, float delayBeforeFade)
    {
        fadeImage.enabled = true;
        canvasGroup.alpha = startAlpha;

        canvasGroup.alpha = startAlpha;
        yield return null;
        yield return new WaitForSeconds(delayBeforeFade);
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float fadePercentage = timeElapsed / duration;
            fadePercentage = Mathf.Clamp01(fadePercentage);
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, fadePercentage);
            yield return null;
        }

        canvasGroup.alpha = endAlpha;

        if (endAlpha <= 0)
        {
            fadeImage.enabled = false;
        }
    }

}

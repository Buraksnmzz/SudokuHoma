using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// This code block is generated for UI animations. More animation modes could be added here.
/// This helper class could be used for future projects to animate UI.
/// </summary>
public class UIAnimationHelper
{
    public static void ScaleUpPunchAnimation(GameObject obj, Vector3 currentScale, float scaleTime, Ease ease)
    {
        obj.transform.localScale = Vector3.zero;
        obj.SetActive(true);
        obj.transform.DOScale(currentScale, scaleTime).SetEase(ease).OnComplete(() => { obj.transform.DOPunchScale(currentScale * 0.1f, 0.1f, 5, 0.5f); });
    }
    public static void ScaleUpAnimation(GameObject obj, Vector3 currentScale, float scaleTime, Ease ease)
    {
        obj.transform.localScale = Vector3.zero;
        obj.SetActive(true);
        obj.transform.DOScale(currentScale, scaleTime).SetEase(ease);
    }
    public static void FadeInAnimation(GameObject obj, Vector3 currentScale, float fadeTime, Ease ease)
    {
        if (obj.GetComponent<CanvasGroup>() == null)
        {
            obj.AddComponent<CanvasGroup>();
        }
        obj.GetComponent<CanvasGroup>().alpha = 0;
        obj.SetActive(true);
        obj.GetComponent<CanvasGroup>()?.DOFade(1, fadeTime).SetEase(ease);
    }
    public static void ScaleDownAnimation(GameObject obj, Vector3 currentScale, float scaleTime, Ease ease)
    {
        obj.SetActive(true);
        obj.transform.DOScale(Vector3.zero, scaleTime).SetEase(ease).OnComplete(() => 
        {
            obj.transform.localScale = currentScale;
            obj.SetActive(false);
        });
    }
    public static void FadeOutAnimation(GameObject obj, Vector3 currentScale, float fadeTime, Ease ease)
    {
        if (obj.GetComponent<CanvasGroup>() == null)
        {
            obj.AddComponent<CanvasGroup>();
        }
        obj.GetComponent<CanvasGroup>()?.DOFade(0, fadeTime).SetEase(ease).OnComplete(() => 
        {
            obj.GetComponent<CanvasGroup>().alpha = 1;
            obj.SetActive(false);
        });
    }

    public static void PunchScaleReactAnimation(GameObject obj, Vector3 punchValue, float punchDuration)
    {
        obj.transform.DOPunchScale(punchValue, punchDuration, 5, 0.5f);
    }
    public static void PunchRotateReactAnimation(GameObject obj, Vector3 punchValue, float punchDuration )
    {
        obj.transform.DOPunchRotation(punchValue, punchDuration, 5, 0.5f);
    }
}

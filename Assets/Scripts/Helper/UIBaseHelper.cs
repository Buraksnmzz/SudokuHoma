using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This code block uses UIAnimationHelper class to perform Show, Hide and React animations in different ways.
/// This helper class could be used for future projects to animate UI.
/// </summary>
public abstract class UIBaseHelper : MonoBehaviour
{
    Button button;

    protected virtual void Awake()
    {
        if(GetComponent<Button>() != null)
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }
    }
    protected virtual void OnEnable()
    {
        
    }
    protected virtual void OnDisable()
    {
        
    }
    protected virtual void OnValidate()
    {
        
    }

    protected virtual void OnClick()
    {

    }
    public virtual void Show(UIAnimationShowMode uIAnimationShowMode, float startAnimationDuration, Ease startAnimationEase)
    {
        transform.DOKill(true);
        Vector3 currentScale = transform.localScale;
        switch (uIAnimationShowMode)
        {
            case UIAnimationShowMode.NONE:
                gameObject.SetActive(true);
                break;
            case UIAnimationShowMode.PUNCHSCALE:
                UIAnimationHelper.ScaleUpPunchAnimation(gameObject, currentScale, startAnimationDuration, startAnimationEase);
                break;
            case UIAnimationShowMode.SCALEUP:
                UIAnimationHelper.ScaleUpAnimation(gameObject, currentScale, startAnimationDuration, startAnimationEase);
                break;
            case UIAnimationShowMode.FADEIN:
                UIAnimationHelper.FadeInAnimation(gameObject, currentScale, startAnimationDuration, startAnimationEase);
                break;
            default:
                gameObject.SetActive(true);
                break;
        }      
    }
    public virtual void Hide(UIAnimationHideMode uIAnimationHideMode, float endAnimationDuration, Ease endAnimationEase)
    {
        transform.DOKill(true);
        Vector3 currentScale = transform.localScale;
        switch (uIAnimationHideMode)
        {
            case UIAnimationHideMode.NONE:
                gameObject.SetActive(false);
                break;
            case UIAnimationHideMode.SCALEDOWN:
                UIAnimationHelper.ScaleDownAnimation(gameObject, currentScale, endAnimationDuration, endAnimationEase);
                break;
            case UIAnimationHideMode.FADEOUT:
                UIAnimationHelper.FadeOutAnimation(gameObject, currentScale, endAnimationDuration, endAnimationEase);
                break;
        }
    }
    public virtual void React(UIAnimationReactMode uIAnimationModeEnum, Vector3 punchValue, float duration)
    {
        transform.DOKill(true);
        Vector3 currentScale = transform.localScale;
        switch (uIAnimationModeEnum)
        {
            case UIAnimationReactMode.NONE:
                gameObject.SetActive(false);
                break;
            case UIAnimationReactMode.PUNCHSCALE:
                UIAnimationHelper.PunchScaleReactAnimation(gameObject, punchValue, duration);
                break;
            case UIAnimationReactMode.PUNCHROTATE:
                UIAnimationHelper.PunchRotateReactAnimation(gameObject, punchValue, duration);
                break;
        }
    }


}

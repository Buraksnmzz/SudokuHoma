using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

/*NOTE:
 * Classes under the Helper folder(Where this class located) are generated to be used in future projects.
 * These UI helper classes provide easiness to make UI animations.
 * This helper folder is exported as a unity package and put under the Homa Case Study Drive folder.
 * This helper folder could be imported to or directly copied under the script folder of other projects to be used.
 * In order to use these UI animation helper classes, related classes should be derived from this (UIBaseHelper) class.
 * 
 * How To Use:
 * For example: the panel called panelEndMenu is derived from UIBaseHelper. 
 * In order to show or hide this panel(panelEndMenu) with animations, UIController class calls the Show() and Hide() methods of panelEndMenu object.
 * This Show() and Hide() methods takes 3 arguments which are AnimationMode enum(type of the animation like fadein/out, scaleup/down, punch),
 * AnimationDuration and Ease(DoTween ease types)
 * This class uses the UIAnimationHelper class to play these animations.
 */
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

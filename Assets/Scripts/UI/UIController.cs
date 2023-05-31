using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Controls the visibility of UI panels and buttons
/// </summary>
public class UIController : MonoBehaviour
{
    public GameObject panelEndMenu;
    public GameObject retryButton;
    public GameObject nextLevelButton;

    private void OnEnable()
    {
        RetryButton.OnRetryButtonClicked += OnNewLevel;
        NextLevelButton.OnNextLevelButtonClicked += OnNewLevel;
        BoardController.OnLevelFinished += OnLevelFinished;
        BoardController.OnLevelFailed += OnLevelFailed;
    }
    private void OnDisable()
    {
        RetryButton.OnRetryButtonClicked -= OnNewLevel;
        NextLevelButton.OnNextLevelButtonClicked -= OnNewLevel;
        BoardController.OnLevelFinished -= OnLevelFinished;
        BoardController.OnLevelFailed -= OnLevelFailed;
    }
    void OnLevelFinished()
    {
        StartCoroutine(ShowFinishPanel());
    }
    void OnLevelFailed()
    {
        panelEndMenu.GetComponent<UIBaseHelper>().Show(UIAnimationShowMode.SCALEUP, 0.5f, Ease.OutExpo);
        retryButton.SetActive(true);
        nextLevelButton.SetActive(false);
    }
    void OnNewLevel()
    {
        panelEndMenu.GetComponent<UIBaseHelper>().Hide(UIAnimationHideMode.FADEOUT, 0.5f, Ease.Linear);
    }
    IEnumerator ShowFinishPanel()
    {
        yield return new WaitForSeconds(1f);
        panelEndMenu.GetComponent<UIBaseHelper>().Show(UIAnimationShowMode.SCALEUP, 0.5f, Ease.OutExpo);
        retryButton.SetActive(false);
        nextLevelButton.SetActive(true);
    }
}

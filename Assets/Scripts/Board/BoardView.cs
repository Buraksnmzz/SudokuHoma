using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// Manages animations on the grids and color arrangement according to the data from the BoardController class.  
/// </summary>
public class BoardView : MonoBehaviour
{
    private List<GameObject> gridObjectList = new List<GameObject>();
    public Image[] mistakeImages = new Image[3];
    int mistakeIndex = 0;
    Color mRedColor = new Color32(234, 4, 59, 255);
    Color mDarkBlueColor = new Color32(0, 60, 180, 255);
    Color mLightBlueColor = new Color32(178, 223, 254, 255);
    Color mWhiteColor = new Color32(245, 247, 255, 255);
    private void OnEnable()
    {
        BoardController.OnNumberWritten += OnNumberWritten;
        BoardController.OnGridSelected += OnFilledGridSelected;
        BoardController.OnLevelFinished += OnLevelFinished;
        GridGenerator.OnGridsGenerated += OnGridsGenerated;
    }
    private void OnDisable()
    {
        BoardController.OnNumberWritten -= OnNumberWritten;
        BoardController.OnGridSelected -= OnFilledGridSelected;
        BoardController.OnLevelFinished -= OnLevelFinished;
        GridGenerator.OnGridsGenerated -= OnGridsGenerated;
    }
    private void OnGridsGenerated(List<GameObject> gridObjectList)
    {
        this.gridObjectList = gridObjectList;
    }
    private void OnNumberWritten(GameObject gridObject, bool isTrueNumber, int number)
    {
        GridButton gridButton = gridObject.GetComponent<GridButton>();
        TextMeshProUGUI gridText = gridObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        gridText.enabled = true;
        gridText.text = number.ToString();
        if (isTrueNumber)
        {
            setNumberColor(gridText, mDarkBlueColor);
            gridButton.React(UIAnimationReactMode.PUNCHSCALE, gridObject.transform.localScale * 0.1f, 0.2f);
        }
        else
        {
            setNumberColor(gridText, mRedColor);
            gridButton.React(UIAnimationReactMode.PUNCHROTATE, new Vector3(0,0,5), 0.2f);
            mistakeImages[mistakeIndex].transform.DOPunchScale(new Vector3(0.15f, 0.15f, 0.15f), 0.2f, 5, 0);
            mistakeImages[mistakeIndex].color = mRedColor;
            mistakeIndex++;
        }
    }
    private void OnFilledGridSelected(GameObject gridObject, bool isFill)
    {
        if(isFill)
        {
            gridObject.GetComponent<Image>().color = mLightBlueColor;
        }
        else
        {
            gridObject.GetComponent<Image>().color = mWhiteColor;
        }
    }
    private void OnLevelFinished()
    {
        StartCoroutine(FinishAnimation());
    }
    IEnumerator FinishAnimation()
    {
        for (int gridIndex = 0; gridIndex < gridObjectList.Count; gridIndex++)
        {
            Sequence sequence = DOTween.Sequence();
            gridObjectList[gridIndex].transform.DOPunchScale(gridObjectList[gridIndex].transform.localScale * 0.06f, 2, 5, 0.2f);
            sequence.Append(gridObjectList[gridIndex].GetComponent<Image>().DOColor(mLightBlueColor, 0.5f));
            sequence.Append(gridObjectList[gridIndex].GetComponent<Image>().DOColor(mWhiteColor, 0.5f));
            yield return new WaitForSeconds(0.02f);
        }
    }
    private void setNumberColor(TextMeshProUGUI tmpText, Color _color)
    {
        tmpText.color = _color;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Implements the logic of grid selection and writing number to selected grid.
/// Triggers these events for BoardView, ParticleController and AudioController classes.
/// Triggers end of level event for UIController
/// </summary>
public class BoardController : MonoBehaviour
{
    public static event Action<GameObject, bool, int> OnNumberWritten;
    public static event Action<bool> OnNumberWrittenSound;
    public static event Action<GameObject, bool> OnNumberWrittenParticle;
    public static event Action<GameObject, bool> OnGridSelected;
    public static event Action OnGridSelectedAudio;
    public static event Action OnLevelFinished;
    public static event Action OnLevelFailed;
    private GameObject selectedGrid = null;
    private GridButton gridButton;
    private List<GameObject> gridObjectList = new List<GameObject>();
    private List<GridButton> gridButtonList = new List<GridButton>();
    private int correctMoveCounter = 0;
    private int wrongMoveCounter = 0;
    private int targetSuccessCount;
    private int targetFailCount = 3;
    
    private void OnEnable()
    {
        GridButton.OnGridButtonClick += OnGridButtonClick;
        NumberButton.OnNumberButtonClick += OnNumberButtonClick;
        GridGenerator.OnGridsGenerated += OnStoreGridObjectList;
    }
    private void OnDisable()
    {
        GridButton.OnGridButtonClick -= OnGridButtonClick;
        NumberButton.OnNumberButtonClick -= OnNumberButtonClick;
        GridGenerator.OnGridsGenerated -= OnStoreGridObjectList;
    }
    /// <summary>
    /// Initialize success count according to the how many grids are closed. 
    /// </summary>
    void Start()
    {
        for (int boardDataIndex = 0; boardDataIndex < BoardData.levelsActive.GetLength(1); boardDataIndex++)
        {
            if(BoardData.levelsActive[0, boardDataIndex] == 0)
            {
                targetSuccessCount++;
            }
        }
    }
    /// <summary>
    /// Sends selected grid info to BoardView class 
    /// </summary>
    void OnGridButtonClick(GameObject gridObject)
    {
        selectedGrid = gridObject;
        gridButton = selectedGrid.GetComponent<GridButton>();
        ClearGridColorEvent();
        ShowGridColorEvent();
        OnGridSelected?.Invoke(selectedGrid, true);
        OnGridSelectedAudio?.Invoke();
    }
    private void ClearGridColorEvent()
    {
        for (int gridIndex = 0; gridIndex < gridObjectList.Count; gridIndex++)
        {
            OnGridSelected?.Invoke(gridObjectList[gridIndex], false);
        }
    }
    /// <summary>
    /// Sends "which numbers are same in the grids" information to BoardView class.
    /// </summary>
    private void ShowGridColorEvent()
    {
        if (!gridButton.isWritable)
        {
            for (int gridObjectListIndex = 0; gridObjectListIndex < gridObjectList.Count; gridObjectListIndex++)
            {
                if (gridButton.numberInGrid == gridButtonList[gridObjectListIndex].numberInGrid)
                {
                    OnGridSelected?.Invoke(gridObjectList[gridObjectListIndex], true);
                }
            }
        }
    }
    /// <summary>
    /// checks if selected @number is correct.
    /// Parameters:
    /// @number: selected number from the bottom numbers.
    /// </summary>
    void OnNumberButtonClick(int number)
    {
        if(gridButton.isWritable)
        {
            if (number == gridButton.numberInGrid)
            {
                OnNumberWritten.Invoke(selectedGrid, true, number);
                OnNumberWrittenSound?.Invoke(true);
                OnNumberWrittenParticle?.Invoke(selectedGrid, true);
                gridButton.isWritable = false;
                correctMoveCounter++;
                if(correctMoveCounter == targetSuccessCount)
                {
                    OnLevelFinished?.Invoke();
                }
            }
            else
            {
                OnNumberWritten.Invoke(selectedGrid, false, number);
                OnNumberWrittenSound?.Invoke(false);
                OnNumberWrittenParticle?.Invoke(selectedGrid, false);
                wrongMoveCounter++;
                if (wrongMoveCounter == targetFailCount)
                {
                    OnLevelFailed?.Invoke();
                }
            }
        }
    }
    void OnStoreGridObjectList(List<GameObject> gridObjectList)
    {
        this.gridObjectList = gridObjectList;
        for (int gridObjectListIndex = 0; gridObjectListIndex < gridObjectList.Count; gridObjectListIndex++)
        {
            gridButtonList[gridObjectListIndex] = gridObjectList[gridObjectListIndex].GetComponent<GridButton>();
        }
    }
}

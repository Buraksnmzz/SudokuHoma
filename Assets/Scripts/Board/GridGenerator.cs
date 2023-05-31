using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Generates grids and assign numbers on the grids.
/// </summary>
public class GridGenerator : MonoBehaviour
{
    public static event Action<List<GameObject>> OnGridsGenerated;
    public GameObject gridObjectPrefab;
    private TextMeshProUGUI gridText;
    public List<GameObject> gridObjectsList = new List<GameObject>();
    private int rowCount = 9;
    int currentLevel;
    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        GenerateGrid();
    }
    void GenerateGrid()
    {
        for (int columnIndex = 0; columnIndex < 9; columnIndex++)
        {
            for (int rowIndex = 0; rowIndex < 9; rowIndex++)
            {
                GameObject instantiatedGrid = Instantiate(gridObjectPrefab, transform.GetChild(columnIndex));
                instantiatedGrid.GetComponent<GridButton>().numberInGrid = BoardData.levelsTarget[currentLevel, columnIndex * rowCount + rowIndex];
                gridObjectsList.Add(instantiatedGrid);
            }
        }
        StartCoroutine(SetGridText());
    }
    IEnumerator SetGridText()
    {
        for (int columnIndex = 0; columnIndex < 9; columnIndex++)
        {
            for (int rowIndex = 0; rowIndex < 9; rowIndex++)
            {
                gridText = gridObjectsList[rowIndex + columnIndex * rowCount].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                gridText.text = BoardData.levelsTarget[currentLevel, columnIndex * rowCount + rowIndex].ToString();
                if (BoardData.levelsActive[currentLevel, columnIndex * rowCount + rowIndex] == 0)
                {
                    gridText.enabled = false;
                    gridObjectsList[rowIndex + columnIndex * rowCount].GetComponent<GridButton>().isWritable = true;
                }
                gridText.transform.DOScale(new Vector3(1, 1, 1), 0.8f).SetEase(Ease.OutBounce);
                yield return new WaitForSeconds(0.005f);
            }
        }
        OnGridsGenerated?.Invoke(gridObjectsList);
    }
}

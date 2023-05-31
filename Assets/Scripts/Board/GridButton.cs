using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Responsible for grid selection
/// Variables:
/// isWritable: if false, number on the grid could not be changed
/// </summary>
public class GridButton : UIBaseHelper
{
    public static event Action<GameObject> OnGridButtonClick;
    public bool isWritable = false;
    public int numberInGrid;
    
    protected override void OnClick()
    {
        OnGridButtonClick?.Invoke(gameObject);
    }
}

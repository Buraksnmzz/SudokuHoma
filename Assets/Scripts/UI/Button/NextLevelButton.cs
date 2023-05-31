using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : UIBaseHelper
{
    public static event Action OnNextLevelButtonClicked;
    protected override void OnClick()
    {
        OnNextLevelButtonClicked?.Invoke();
    }
}

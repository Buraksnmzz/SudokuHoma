using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

/// <summary>
/// Responsible for bottom number selection
/// </summary>
public class NumberButton : UIBaseHelper
{
    public static event Action<int> OnNumberButtonClick;
    private int numberInButton;
    protected override void OnClick()
    {
        OnNumberButtonClick?.Invoke(numberInButton);
        React(UIAnimationReactMode.PUNCHSCALE, transform.localScale * 0.1f, 0.2f);
    }
    public void SetNumberInButton(int number)
    {
        numberInButton = number;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = number.ToString();
    }
}

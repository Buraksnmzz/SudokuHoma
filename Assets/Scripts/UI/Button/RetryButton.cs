using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : UIBaseHelper
{
    public static event Action OnRetryButtonClicked;
    protected override void OnClick()
    {
        OnRetryButtonClicked?.Invoke();
    }
}

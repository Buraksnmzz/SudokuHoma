using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads Game Menu
/// </summary>
public class PlayButton : UIBaseHelper
{
    public static event Action OnPlayButtonClicked;
    protected override void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}

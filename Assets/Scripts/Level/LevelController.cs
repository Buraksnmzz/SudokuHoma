using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Responsible for loading related level.
/// </summary>
public class LevelController : MonoBehaviour
{
    private void OnEnable()
    {
        NextLevelButton.OnNextLevelButtonClicked += OnLoadNextLevel;
        RetryButton.OnRetryButtonClicked += OnLoadCurrentLevel;
    }
    private void OnDisable()
    {
        NextLevelButton.OnNextLevelButtonClicked -= OnLoadNextLevel;
        RetryButton.OnRetryButtonClicked -= OnLoadCurrentLevel;
    }
    private void Start()
    {
        if(!PlayerPrefs.HasKey("currentLevel"))
        {
            PlayerPrefs.SetInt("currentLevel", 0);
        }
    }
    void OnLoadNextLevel()
    {
        if(PlayerPrefs.GetInt("currentLevel") == 1)
        {
            PlayerPrefs.SetInt("currentLevel", 0);
        }
        else
        {
            PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
        }
        StartCoroutine(SceneLoad());
    }
    void OnLoadCurrentLevel()
    {
        StartCoroutine(SceneLoad());
    }
    IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }
}

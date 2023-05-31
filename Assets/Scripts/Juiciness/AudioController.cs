using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays related audio clips
/// </summary>
public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gridClickClip;
    public AudioClip correctNumberClip;
    public AudioClip wrongNumberClip;
    public AudioClip levelSuccessClip;
    public AudioClip playButtonClip;
    public AudioClip levelFailClip;
    public AudioClip levelStartClip;

    private void OnEnable()
    {
        BoardController.OnNumberWrittenSound += OnCorrectNumberSound;
        BoardController.OnGridSelectedAudio += OnGridClickSound;
        BoardController.OnLevelFinished += OnLevelSuccessSound;
        BoardController.OnLevelFailed += OnLevelFailedSound;
    }
    private void OnDisable()
    {
        BoardController.OnNumberWrittenSound -= OnCorrectNumberSound;
        BoardController.OnGridSelectedAudio -= OnGridClickSound;
        BoardController.OnLevelFinished -= OnLevelSuccessSound;
        BoardController.OnLevelFailed -= OnLevelFailedSound;
    }
    private void Start()
    {
        OnLevelStarted();
    }
    void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    void OnGridClickSound()
    {
        PlaySound(gridClickClip);
    }
    void OnCorrectNumberSound(bool isTrue)
    {
        if(isTrue)
        {
            PlaySound(correctNumberClip);
        }
        else
        {
            PlaySound(wrongNumberClip);
        }
    }
    
    void OnLevelSuccessSound()
    {
        PlaySound(levelSuccessClip);
    }
    void OnPlayButtonSound()
    {
        PlaySound(playButtonClip);
    }
    void OnLevelFailedSound()
    {
        PlaySound(levelFailClip);
    }
    void OnLevelStarted()
    {
        PlaySound(levelStartClip);
    }



}

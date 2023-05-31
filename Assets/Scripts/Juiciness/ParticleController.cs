using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays related particles
/// </summary>
public class ParticleController : MonoBehaviour
{
    public ParticleSystem successParticle;
    public ParticleSystem correctParticle;
    public ParticleSystem wrongParticle;
    private void OnEnable()
    {
        BoardController.OnNumberWrittenParticle += OnPlayNumberWrittenParticle;
        BoardController.OnLevelFinished += OnSuccessParticle;
    }
    private void OnDisable()
    {
        BoardController.OnNumberWrittenParticle -= OnPlayNumberWrittenParticle;
        BoardController.OnLevelFinished -= OnSuccessParticle;
    }
    void OnSuccessParticle()
    {
        successParticle.Play();
    }
    void OnPlayNumberWrittenParticle(GameObject obj, bool isTrue)
    {
        if(isTrue)
        {
            correctParticle.transform.position = obj.transform.position;
            correctParticle.Play();
        }
        else
        {
            wrongParticle.transform.position = obj.transform.position;
            wrongParticle.Play();
        }
        
    }
}

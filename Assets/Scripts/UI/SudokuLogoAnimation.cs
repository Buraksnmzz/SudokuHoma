using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SudokuLogoAnimation : MonoBehaviour
{
    [SerializeField] float targetScale;
    [SerializeField] float animationTime;
    void Start()
    {
        transform.DOScale(new Vector3(targetScale, targetScale, targetScale), animationTime).SetLoops(-1, LoopType.Yoyo);
    }
}

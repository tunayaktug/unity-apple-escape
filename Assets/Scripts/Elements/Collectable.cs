using DG.Tweening;
using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
  
    void Start()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        transform.DOMoveY(transform.position.y + 1, .5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
        transform.DORotate(Vector3.up * 90, .5f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}

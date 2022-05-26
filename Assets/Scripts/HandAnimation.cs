using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HandAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tween myTween = GetComponent<RectTransform>().DOLocalMove(new Vector3(-20, -60, 0), 1.5f);
        myTween.SetEase(Ease.OutSine);
        myTween.SetLoops(3, LoopType.Restart);
        myTween.OnComplete(Dis);
    }

    public void Dis()
    {
        this.gameObject.SetActive(false);
    }

}

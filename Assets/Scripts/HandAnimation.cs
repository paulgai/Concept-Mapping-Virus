using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HandAnimation : MonoBehaviour
{
    public Vector3 Target = new Vector3(210, 0, 0);
    private void OnEnable()
    {
        //Vector3[] v = new Vector3[4];
        //Vector3 pos = Camera.main.ScreenToWorldPoint(handTarget.GetComponent<RectTransform>().transform.position);
        //handTarget.GetComponent<RectTransform>().GetWorldCorners(v);
        //Vector3 pos = handTarget.GetComponent<RectTransform>().position;
        //Debug.Log("handTarget=" + handTarget.GetComponent<RectTransform>().position);
       // Debug.Log("Vector3(0, 50, 0)");
        //Tween myTween = GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 0, 50), 1.3f);
        Tween myTween = this.transform.DOLocalMove(Target, 1.3f);
        myTween.SetEase(Ease.OutSine);
        myTween.SetLoops(4, LoopType.Restart);
        myTween.OnComplete(Dis);
    }

    public void Dis()
    {
        this.gameObject.SetActive(false);
    }
  

}

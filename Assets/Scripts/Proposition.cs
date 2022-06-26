using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Proposition : MonoBehaviour
{
   
    private void OnEnable()
    {
        Sequence mySequence = DOTween.Sequence();
        for (int i = 0; i < this.gameObject.transform.childCount; i++) 
        {
            RectTransform rt = this.gameObject.transform.GetChild(i).GetComponent<RectTransform>();
            Vector3 InitScale = rt.localScale;            
            rt.localScale = new Vector3(0, 0, 0);
            mySequence.Append(rt.DOScale(InitScale, 0.15f));
            
        }
    }
}

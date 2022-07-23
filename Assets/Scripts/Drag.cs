using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class
Drag
:
MonoBehaviour,
IDragHandler,
IPointerClickHandler,
IBeginDragHandler,
IEndDragHandler
{
    public GameObject Image;

    public GameObject CorrectPanel;

    public bool isDragEnebled = true;

    private Vector3 dragOffset;

    private float distance = 100;

    private float minDistance = 0.5f;

    private Vector3 StartPos;

    private bool flag = false;

    void Start()
    {
        StartPos = GetComponent<RectTransform>().localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 worldPoint;
        RectTransformUtility
            .ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera,
            out worldPoint);
        dragOffset = GetComponent<RectTransform>().position - worldPoint;

        GameObject Panel = this.GetComponent<Drag>().CorrectPanel;
        flag = Panel.transform.parent.gameObject.activeSelf;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragEnebled)
        {
            //Debug.Log("end");
            GoToStart();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragEnebled)
        {
            SetDraggedPosition (eventData);
            distance =
                Vector3
                    .Distance(GetComponent<RectTransform>().position,
                    CorrectPanel.GetComponent<RectTransform>().position);

            //Debug.Log("distance: " + distance);
            if (distance < minDistance && flag)
            {
                GetComponent<RectTransform>().anchorMin =
                    new Vector2(0.5f, 0.5f);
                GetComponent<RectTransform>().anchorMax =
                    new Vector2(0.5f, 0.5f);
                GetComponent<RectTransform>().position =
                    CorrectPanel.GetComponent<RectTransform>().position;
                if (Image != null)
                {
                    Image.GetComponent<FadeInOut>().StopAnimation();
                }
                GameObject.Find("Canvas").GetComponent<GV>().Correct++;
                isDragEnebled = false;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        Vector3 worldPoint;
        if (
            RectTransformUtility
                .ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>(
                ),
                data.position,
                data.pressEventCamera,
                out worldPoint)
        )
        {
            GetComponent<RectTransform>().position = worldPoint + dragOffset;
        }
    }

    private void GoToStart()
    {
        Tween myTween =
            GetComponent<RectTransform>().DOLocalMove(StartPos, 0.5f);
        myTween.SetEase(Ease.OutSine);
    }
}

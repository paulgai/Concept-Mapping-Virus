using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IPointerClickHandler, IBeginDragHandler
{
    public GameObject Image;
    public GameObject CorrectPanel;
    public bool isDragEnebled = true;
    private Vector3 dragOffset;
    private float distance = 100;
    private float minDistance = 0.5f;
    void Start()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 worldPoint;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out worldPoint);
        dragOffset = GetComponent<RectTransform>().position - worldPoint;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragEnebled)
        {
            SetDraggedPosition(eventData);
            distance = Vector3.Distance(GetComponent<RectTransform>().position,
            CorrectPanel.GetComponent<RectTransform>().position);
            //Debug.Log("distance: " + distance);
            if (distance < minDistance)
            {
                GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                GetComponent<RectTransform>().position = CorrectPanel.GetComponent<RectTransform>().position;
                Image.GetComponent<FadeInOut>().StopAnimation();
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
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>(), data.position, data.pressEventCamera, out worldPoint))
        {
            GetComponent<RectTransform>().position = worldPoint + dragOffset;
        }
    }


}

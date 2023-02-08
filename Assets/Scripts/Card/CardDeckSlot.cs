using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDeckSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
        var cardTransform = eventData.pointerDrag.transform;
        cardTransform.SetParent(transform);
        cardTransform.localPosition = Vector3.zero;
        cardTransform.GetComponent<CardDragAndDrop>()._cardUI.CancelFillingImage();
    }

    
}

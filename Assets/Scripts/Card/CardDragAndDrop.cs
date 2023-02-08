using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;

    private Vector2 _startPosition;
    private Vector3 _startRotation;
    

    private Transform _currentCanvas;
    private Transform _dragAndDropCanvas;

    private CardsDeck _cardsDeck;
    private Card_UI _cardUI;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = transform.position;
        _startRotation = transform.rotation.eulerAngles;
        _canvasGroup = GetComponent<CanvasGroup>();
        _cardsDeck = GetComponentInParent<CardsDeck>();
        _cardUI = GetComponentInParent<Card_UI>();
        _currentCanvas = _cardsDeck.currentCanvas;
        _dragAndDropCanvas = _cardsDeck.dragAndDropCanvas;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.6f;
        _cardUI.StartIgnoreRaycasts();
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();
        transform.parent = _dragAndDropCanvas;
        transform.rotation = Quaternion.identity;
        _cardsDeck.currentCards.Remove(this.GetComponent<CardValues>());
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
        Debug.Log("Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");
        if (transform.parent == _dragAndDropCanvas)
        {
            _cardsDeck.currentCards.Add(this.GetComponent<CardValues>());
            transform.parent = _currentCanvas;
            _rectTransform.anchoredPosition = _startPosition;
            transform.Rotate(_startRotation);
            _cardsDeck.ResetCardsRotation();
            _cardUI.CancelIgnoreRaycasts();
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}

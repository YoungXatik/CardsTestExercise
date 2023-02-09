using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;

    private Vector2 _startPosition = new Vector2(-800,-800);
    private Vector3 _startRotation;
    

    private Transform _currentCanvas;
    private Transform _dragAndDropCanvas;
    public Card_UI _cardUI { get; private set; }

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startRotation = transform.rotation.eulerAngles;
        _canvasGroup = GetComponent<CanvasGroup>();
        _cardUI = GetComponentInParent<Card_UI>();
        _currentCanvas = CardsDeck.Instance.currentCanvas;
        _dragAndDropCanvas = CardsDeck.Instance.dragAndDropCanvas;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        UpScaleCardInHand();
        _canvasGroup.blocksRaycasts = false;
        _cardUI.StartIgnoreRaycasts();
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();
        transform.parent = _dragAndDropCanvas;
        transform.rotation = Quaternion.identity;
        CardsDeck.Instance.currentCards.Remove(this.GetComponent<CardValues>());
        _cardUI.StartFillingImage();
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
            CardsDeck.Instance.currentCards.Add(this.GetComponent<CardValues>());
            _rectTransform.DOLocalMove(_startPosition, 0.25f).SetEase(Ease.Linear).OnComplete(delegate
            {
                transform.parent = _currentCanvas;
            });
            transform.DORotate(_startRotation,0.25f).SetEase(Ease.Linear);
            CardsDeck.Instance.ResetCardsRotation();
        }
        DownScaleCardOnDeck();
        _cardUI.CancelIgnoreRaycasts();
        _canvasGroup.blocksRaycasts = true;
        _cardUI.CancelFillingImage();
    }

    private void UpScaleCardInHand()
    {
        transform.DOScale(transform.localScale * 1.4f, 0.15f).SetEase(Ease.Linear);
    }

    private void DownScaleCardOnDeck()
    {
        transform.DOScale(1, 0.15f).SetEase(Ease.Linear);
    }
}

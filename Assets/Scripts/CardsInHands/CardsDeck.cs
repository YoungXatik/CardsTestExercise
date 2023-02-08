using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardsDeck : MonoBehaviour
{
    public static CardsDeck Instance;

    #region Singleton

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    [SerializeField] private float spawnDelay;

    [SerializeField] private Vector2 spawnOffScreenPosition;
    
    [SerializeField] private Vector2 firstCardInCardPlacement;

    [SerializeField] private Vector2 cardOffset;
    [SerializeField] private float startZRotation;
    private float _rotationZOffset;

    public List<CardValues> cards = new List<CardValues>();
    public List<CardValues> currentCards = new List<CardValues>();

    [SerializeField] private int maxCardsCount;

    private int _minCardsCount = 3;
    private int _cardsCount;

    private int _currentCardIndex;

    public Transform currentCanvas;
    public Transform dragAndDropCanvas;
    private void Start()
    {
        StartCoroutine(SpawnCards());
    }

    private IEnumerator SpawnCards()
    {
        _cardsCount = Random.Range(_minCardsCount, maxCardsCount);
        _rotationZOffset = 2 * (startZRotation / _cardsCount);

        for (int i = 0; i < _cardsCount; i++)
        {
            Vector2 currentCardPosition = new Vector2(firstCardInCardPlacement.x + (cardOffset.x * currentCards.Count),
                firstCardInCardPlacement.y + (cardOffset.y * currentCards.Count));
            currentCards.Add(Instantiate(cards[Random.Range(0, cards.Count)], spawnOffScreenPosition, Quaternion.identity,
                dragAndDropCanvas));
            currentCards[i].transform.DOLocalMove(currentCardPosition, spawnDelay).SetEase(Ease.Linear).OnComplete(
                delegate
                {
                    currentCards[i].transform.parent = currentCanvas;
                });
            currentCards[i].transform.rotation =
                Quaternion.Euler(0, 0, startZRotation - (currentCards.Count * _rotationZOffset));
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void RefreshCardState()
    {
        currentCards[_currentCardIndex].ResetCardValue();
        _currentCardIndex++;
        if (_currentCardIndex == currentCards.Count)
        {
            _currentCardIndex = 0;
        }
    }

    public void ResetCardsRotation()
    {
        _rotationZOffset = 2 * (startZRotation / _cardsCount);
        for (int i = 0; i < currentCards.Count; i++)
        {
            currentCards[i].transform.rotation = Quaternion.Euler(0,0,startZRotation - (i * _rotationZOffset));
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardsDeck : MonoBehaviour
{
    [SerializeField] private Vector2 firstCardInCardPlacement;

    [SerializeField] private Vector2 cardOffset;
    [SerializeField] private float startZRotation;
    [SerializeField] private float rotationZOffset;
    public static CardsDeck Instance;

    #region Singleton

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    
    public List<CardValues> cards = new List<CardValues>();
    public List<CardValues> currentCards = new List<CardValues>();
    
    [SerializeField] private int maxCardsCount;

    private int _minCardsCount = 3;
    private int _cardsCount;

    private void Start()
    {
        _cardsCount = Random.Range(_minCardsCount, maxCardsCount);
        rotationZOffset = 2 * (startZRotation / _cardsCount);

        for (int i = 0; i < _cardsCount; i++)
        {
            Vector2 currentCardPosition = new Vector2(firstCardInCardPlacement.x + (cardOffset.x * currentCards.Count),firstCardInCardPlacement.y + (cardOffset.y * currentCards.Count));
            currentCards.Add(Instantiate(cards[Random.Range(0, cards.Count)],Vector3.zero, Quaternion.identity,gameObject.transform));
            currentCards[i].transform.localPosition = currentCardPosition;
            currentCards[i].transform.rotation = Quaternion.Euler(0,0,startZRotation - (currentCards.Count * rotationZOffset));
        }
    }
}

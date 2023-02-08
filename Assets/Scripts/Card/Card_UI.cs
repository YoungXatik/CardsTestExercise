using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card_UI : MonoBehaviour
{
    private CardValues _card;
    
    [SerializeField] private Image cardImage;

    [SerializeField] private TextMeshProUGUI cardName, cardDescription;

    [SerializeField] private TextMeshProUGUI attackText, healthText, manaText;

    private void OnEnable()
    {
        Events.OnCardValuesReset += UpdateUI;
    }

    private void OnDisable()
    {
        Events.OnCardValuesReset -= UpdateUI;
    }

    private void Awake()
    {
        _card = GetComponent<CardValues>();
    }
    
    private void Start()
    {
        _card.ResetCardValue();
        UpdateUI();
    }

    private void UpdateUI()
    {
        cardImage.sprite = _card.heroSprite;
        cardName.text = _card.heroName;
        cardDescription.text = _card.heroDescription;
        attackText.text = $"{_card.AttackValue}";
        healthText.text = $"{_card.HealthValue}";
        manaText.text = $"{_card.ManaValue}";
    }
} 

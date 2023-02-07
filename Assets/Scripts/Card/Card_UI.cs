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

    private void Awake()
    {
        _card = GetComponent<CardValues>();
    }
    
    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        cardImage.sprite = _card.CurrentHero.heroSprite;
        cardName.text = _card.CurrentHero.heroName;
        cardDescription.text = _card.CurrentHero.heroDescription;
        attackText.text = $"{_card.CurrentHero.AttackValue}";
        healthText.text = $"{_card.CurrentHero.HealthValue}";
        manaText.text = $"{_card.CurrentHero.ManaValue}";
    }

    private void ResetCardValue()
    {
        _card.CurrentHero.ResetCardValue();
        UpdateUI();
    }
} 

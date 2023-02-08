using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card_UI : MonoBehaviour
{
    private CardValues _card;

    [SerializeField] private Image cardImage;
    [SerializeField] private Image cardHeroImage;

    [SerializeField] private TextMeshProUGUI cardName, cardDescription;

    [SerializeField] private TextMeshProUGUI attackText, healthText, manaText;

    [SerializeField] private Image backgroundImage;

    private Sequence Seq;
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

    public void UpdateUI()
    {
        cardHeroImage.sprite = _card.heroSprite;
        cardName.text = _card.heroName;
        cardDescription.text = _card.heroDescription;
        attackText.text = $"{Mathf.RoundToInt(_card.AttackValue)}";
        healthText.text = $"{Mathf.RoundToInt(_card.HealthValue)}";
        manaText.text = $"{Mathf.RoundToInt(_card.ManaValue)}";
    }

    public void StartIgnoreRaycasts()
    {
        cardHeroImage.raycastTarget = false;
        cardImage.raycastTarget = false;
        backgroundImage.raycastTarget = false;
    }

    public void CancelIgnoreRaycasts()
    {
        cardHeroImage.raycastTarget = true;
        cardImage.raycastTarget = true;
        backgroundImage.raycastTarget = true;
    }

    public void StartFillingImage()
    {
        Seq = DOTween.Sequence();
        Seq.Append(backgroundImage.DOFillAmount(0, 0.4f).SetEase(Ease.Linear).OnComplete(delegate
        {
            backgroundImage.DOFillAmount(0, 0.4f).SetEase(Ease.Linear);
        }));
        Seq.SetLoops(-1);
    }

    public void CancelFillingImage()
    {
        Seq.Kill();
        backgroundImage.DOFillAmount(1, 0.1f);
    }
} 

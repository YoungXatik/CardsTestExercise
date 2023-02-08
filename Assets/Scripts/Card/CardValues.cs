using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardValues : MonoBehaviour
{
    private Card_UI _cardUI;
    
    public Sprite heroSprite;

    public string heroName;
    public string heroDescription;

    [Range(2,9)]
    [SerializeField] private int maxAttackValue;
    private int _minAttackValue = 2;
    public float AttackValue { get; private set; }
    
    [Range(2,9)]
    [SerializeField] private int maxHealthValue;
    private int _minHealthValue = 2;
    public float HealthValue { get; private set; }
    
    [Range(2,9)]
    [SerializeField] private int maxManaValue;
    private int _minManaValue = 2;
    public float ManaValue { get; private set; }

    private void Awake()
    {
        _cardUI = GetComponent<Card_UI>();
    }

    public void ResetCardValue()
    {
        var newAttackValue = Random.Range(_minAttackValue, maxAttackValue);
        DOTween.To(x => AttackValue = x, _minAttackValue, newAttackValue, 0.3f).SetEase(Ease.Linear).OnUpdate(delegate
        {
            _cardUI.UpdateUI();
        });
        var newHealthValue = HealthValue = Random.Range(_minHealthValue, maxHealthValue);
        DOTween.To(x => HealthValue = x, _minHealthValue, newHealthValue, 0.3f).SetEase(Ease.Linear).OnUpdate(delegate
        {
            _cardUI.UpdateUI();
        });
        var newManaValue = Random.Range(_minManaValue, maxManaValue);
        DOTween.To(x => ManaValue = x, _minManaValue, newManaValue, 0.3f).SetEase(Ease.Linear).OnUpdate(delegate
        {
            _cardUI.UpdateUI();
        });
        Events.OnCardValueResetInvoke();
    }
}

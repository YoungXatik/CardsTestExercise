using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardValues : MonoBehaviour
{
    public Sprite heroSprite;

    public string heroName;
    public string heroDescription;

    [Range(2,9)]
    [SerializeField] private int maxAttackValue;
    private int _minAttackValue = 2;
    public int AttackValue { get; private set; }
    
    [Range(2,9)]
    [SerializeField] private int maxHealthValue;
    private int _minHealthValue = 2;
    public int HealthValue { get; private set; }
    
    [Range(2,9)]
    [SerializeField] private int maxManaValue;
    private int _minManaValue = 2;
    public int ManaValue { get; private set; }

    public void ResetCardValue()
    {
        AttackValue = Random.Range(_minAttackValue, maxAttackValue);
        HealthValue = Random.Range(_minHealthValue, maxHealthValue);
        ManaValue = Random.Range(_minManaValue, maxManaValue);
        Events.OnCardValueResetInvoke();
    }
}

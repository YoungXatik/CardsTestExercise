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

    [SerializeField] private int maxAttackValue, minAttackValue;
    public int AttackValue { get; private set; }
    
    [SerializeField] private int maxHealthValue, minHealthValue;
    public int HealthValue { get; private set; }
    
    [SerializeField] private int maxManaValue, minManaValue;
    public int ManaValue { get; private set; }

    private void Start()
    {
        ResetCardValue();
    }

    public void ResetCardValue()
    {
        AttackValue = Random.Range(minAttackValue, maxAttackValue);
        HealthValue = Random.Range(minHealthValue, maxHealthValue);
        ManaValue = Random.Range(minManaValue, maxManaValue);
    }
}

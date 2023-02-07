using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardValues : MonoBehaviour
{
    public CardHeroes CurrentHero;

    private void Start()
    {
        CurrentHero.ResetCardValue();
    }
}

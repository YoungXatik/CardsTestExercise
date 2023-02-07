using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Create New Card Hero")]
public class CardHeroes : ScriptableObject
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
    
    public void ResetCardValue()
    {
        AttackValue = Random.Range(minAttackValue, maxAttackValue);
        HealthValue = Random.Range(minHealthValue, maxHealthValue);
        ManaValue = Random.Range(minManaValue, maxManaValue);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Item Values")]
    [Space]
    public string Name = "New Item";
    public ItemCategory Category;
    public int Rarity;
    public int Damage;
    public int HealthPoints;
    public int Defense;
    public float LifeSteal;
    public float CriticalStrikeChance;
    public float AttackSpeed;
    public float MovementSpeed;
    public float Luck;

    [Header("Item UI")]
    [Space]
    public Sprite ItemIcon;
}

public enum ItemCategory
{
    Armor,
    Boots,
    Helmet,
    Necklace,
    Ring,
    Weapon
}
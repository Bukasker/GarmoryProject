using UnityEngine;

public class PlayerStats : CharacterStats
{
    [SerializeField] private StatsUI StatsUI;
    void Start()
    {
        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChanged; 
        currentHealth = MaxHealthPointsStat.GetValue();
    }

    void OnEquipmentChanged(Item newItem, Item oldItem)
    {
        if (newItem != null)
        {
            DamageStat.AddModifier(newItem.Damage);
            MaxHealthPointsStat.AddModifier(newItem.HealthPoints);
            DefenseStat.AddModifier(newItem.Defense);
            LifeStealStat.AddModifier(newItem.LifeSteal);
            CriticalStrikeChanceStat.AddModifier(newItem.CriticalStrikeChance);
            AttackSpeedStat.AddModifier(newItem.AttackSpeed);
            MovementSpeedStat.AddModifier(newItem.MovementSpeed);
            LuckStat.AddModifier(newItem.Luck);
        }
        if (oldItem != null)
        {
            DamageStat.RemoveModifier(oldItem.Damage);
            MaxHealthPointsStat.RemoveModifier(oldItem.HealthPoints);
            DefenseStat.RemoveModifier(oldItem.Defense);
            LifeStealStat.RemoveModifier(oldItem.LifeSteal);
            CriticalStrikeChanceStat.RemoveModifier(oldItem.CriticalStrikeChance);
            AttackSpeedStat.RemoveModifier(oldItem.AttackSpeed);
            MovementSpeedStat.RemoveModifier(oldItem.MovementSpeed);
            LuckStat.RemoveModifier(oldItem.Luck);
        }
        StatsUI.UpdateStatsUI();
    }
}

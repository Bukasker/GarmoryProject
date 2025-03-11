using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Basic stats")]
    public float MinHealth = 0;
    public Stat DamageStat;
    public Stat MaxHealthPointsStat;
    public Stat DefenseStat;
    public Stat LifeStealStat;
    public Stat CriticalStrikeChanceStat;
    public Stat AttackSpeedStat;
    public Stat MovementSpeedStat;
    public Stat LuckStat;

    public float currentHealth;


    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {

    }
}

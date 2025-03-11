using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    [SerializeField] private Slider slider;
    [SerializeField] private int maxHealthRange = 500;
    void Awake()
    {
        MaxHealthPointsStat.baseValue = Random.Range(0, maxHealthRange);
        currentHealth = MaxHealthPointsStat.GetValue();

        slider.maxValue = MaxHealthPointsStat.GetValue();
        slider.minValue = MinHealth;
        slider.value = MaxHealthPointsStat.GetValue(); ;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        slider.value = currentHealth;
    }

    public override void Die()
    {
        base.Die();
        Destroy(this.gameObject);
    }
}

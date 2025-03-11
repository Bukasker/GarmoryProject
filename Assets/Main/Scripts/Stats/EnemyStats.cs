using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    [SerializeField] private Slider slider;
    [SerializeField] private int maxHealthRange = 500;
    [SerializeField] private TextMeshProUGUI tmp;
    void Awake()
    {
        MaxHealthPointsStat.baseValue = UnityEngine.Random.Range(0, maxHealthRange);
        currentHealth = MaxHealthPointsStat.GetValue();

        slider.maxValue = MaxHealthPointsStat.GetValue();
        slider.minValue = MinHealth;
        slider.value = MaxHealthPointsStat.GetValue();
        tmp.text = Convert.ToString(currentHealth + "/" + MaxHealthPointsStat.GetValue());
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        slider.value = currentHealth;
        tmp.text = Convert.ToString(currentHealth+"/"+MaxHealthPointsStat.GetValue());
    }

    public override void Die()
    {
        base.Die();
        Destroy(this.gameObject);
    }
}

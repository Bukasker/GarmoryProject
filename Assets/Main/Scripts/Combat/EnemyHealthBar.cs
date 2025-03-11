using UnityEngine;
using UnityEngine.UIElements;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private Slider healthSlider; 

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        healthSlider.value = characterStats.MaxHealthPointsStat.GetValue();

        HealthChanged();
    }

    public void HealthChanged()
    {
        healthSlider.value = characterStats.currentHealth;
    }

}

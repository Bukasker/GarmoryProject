using UnityEngine;
using UnityEngine.UIElements;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private UIDocument statsUIDocument;
    [SerializeField] private PlayerStats playerStats;

    private Label damageLabel;
    private Label maxHealthLabel;
    private Label defenseLabel;
    private Label lifeStealLabel;
    private Label critChanceLabel;
    private Label attackSpeedLabel;
    private Label movementSpeedLabel;
    private Label luckLabel;

    private void Start()
    {

        if (statsUIDocument == null || playerStats == null)
        {
            return;
        }

        VisualElement root = statsUIDocument.rootVisualElement;

        damageLabel = root.Q<Label>("DamageLabel");
        maxHealthLabel = root.Q<Label>("MaxHealthLabel");
        defenseLabel = root.Q<Label>("DefenseLabel");
        lifeStealLabel = root.Q<Label>("LifeStealLabel");
        critChanceLabel = root.Q<Label>("CritChanceLabel");
        attackSpeedLabel = root.Q<Label>("AttackSpeedLabel");
        movementSpeedLabel = root.Q<Label>("MovementSpeedLabel");
        luckLabel = root.Q<Label>("LuckLabel");

        UpdateStatsUI(); 
    }

    public void UpdateStatsUI()
    {
        if (playerStats == null) return;

        damageLabel.text = $"DMG: {playerStats.DamageStat.GetValue():F1}";
        maxHealthLabel.text = $"HP: {playerStats.MaxHealthPointsStat.GetValue():F1}";
        defenseLabel.text = $"DEF: {playerStats.DefenseStat.GetValue():F1}";
        lifeStealLabel.text = $"LS: {playerStats.LifeStealStat.GetValue():P1}";
        critChanceLabel.text = $"Crit: {playerStats.CriticalStrikeChanceStat.GetValue():P1}";
        attackSpeedLabel.text = $"AS: {playerStats.AttackSpeedStat.GetValue():F2}";
        movementSpeedLabel.text = $"MS: {playerStats.MovementSpeedStat.GetValue():F2}";
        luckLabel.text = $"Luck: {playerStats.LuckStat.GetValue():F1}";
    }
}

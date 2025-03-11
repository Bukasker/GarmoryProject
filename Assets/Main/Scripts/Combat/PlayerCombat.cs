
public class PlayerCombat : CharacterCombat
{
    public override void Attack(CharacterStats targesStats)
    {
        targesStats.TakeDamage(myStats.DamageStat.GetValue());
    }
}

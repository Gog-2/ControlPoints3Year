using BehavioralPatterns.Unit;

namespace BehavioralPatterns.Weapons;

public class Staff : IWeapon
{
    public string Name => "Посох тайных знаний";
    public int DamageBonus => 3;
    public int AccuracyBonus => 10;
    public string AttackVerb => "взрывы";

    public void OnAttack(AbstractUnit attacker, IDamagble target)
    {
        int rawDamage = attacker.Power;
        target.TakeDamage(rawDamage);
        attacker.Restore(2);
    }
}
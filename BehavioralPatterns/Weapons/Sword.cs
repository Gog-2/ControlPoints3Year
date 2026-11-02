using BehavioralPatterns.Unit;

namespace BehavioralPatterns.Weapons;

public class Sword : IWeapon
{
    public string Name => "Железный мечь";
    public int DamageBonus => 5;
    public int AccuracyBonus => 0;
    public string AttackVerb => "косые черты";

    public void OnAttack(AbstractUnit attacker, IDamagble target)
    {
        if (Random.Shared.Next(100) < 20)
        {
            Console.WriteLine("Критический урон");
            target.TakeDamage(attacker.Power + 10);
        }
    }
}
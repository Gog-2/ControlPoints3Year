using BehavioralPatterns.Unit;

namespace BehavioralPatterns.Weapons;

public class Dagger : IWeapon
{
    public string Name => "Теневой кинжал";
    public int DamageBonus => 2;
    public int AccuracyBonus => 20;
    public string AttackVerb => "удары ножом";

    public void OnAttack(AbstractUnit attacker, IDamagble target)
    {
        int hits = Random.Shared.Next(1, 4);
        Console.WriteLine($" {hits} ");
        for (int i = 0; i < hits; i++)
        {
            target.TakeDamage(Math.Max(1, attacker.Power / 2));
        }
    }
}
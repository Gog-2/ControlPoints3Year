using BehavioralPatterns.Unit;

namespace BehavioralPatterns.Weapons;

public class Bow : IWeapon
{
    public string Name => "Охотничий лук";
    public int DamageBonus => 4;
    public int AccuracyBonus => 15;
    public string AttackVerb => "пронзает";

    public void OnAttack(AbstractUnit attacker, IDamagble target)
    {
        if (Random.Shared.Next(100) < 30)
        {
            Console.WriteLine("Попадание в голову");
            target.TakeDamage(attacker.Power + 8);
        }
    }
}
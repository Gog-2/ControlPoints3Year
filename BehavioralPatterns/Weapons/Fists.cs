using BehavioralPatterns.Unit;

namespace BehavioralPatterns.Weapons;

public class Fists : IWeapon
{
    public string Name => "Руки";
    public int DamageBonus => 0;
    public int AccuracyBonus => 0;
    public string AttackVerb => "удары";

    public void OnAttack(AbstractUnit attacker, IDamagble target)
    {
    }
}
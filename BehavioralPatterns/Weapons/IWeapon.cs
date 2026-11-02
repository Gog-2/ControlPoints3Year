using BehavioralPatterns.Unit;

namespace BehavioralPatterns.Weapons;

public interface IWeapon
{
    string Name { get; }
    int DamageBonus { get; }
    int AccuracyBonus { get; }
    string AttackVerb { get; }
    void OnAttack(AbstractUnit attacker, IDamagble target);
}
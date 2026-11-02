using BehavioralPatterns.CommandsAttack;

namespace BehavioralPatterns.Unit;

public class Warrior : AbstractUnit
{
    public Warrior(string name) : base(name, health: 120, power: 18, defense: 10) { }

    public override IBattleCommand Attack(IDamagble target)
        => new AttackCommand(this, target, Weapon);
}
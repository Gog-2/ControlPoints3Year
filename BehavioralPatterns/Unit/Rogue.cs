using BehavioralPatterns.CommandsAttack;

namespace BehavioralPatterns.Unit;

public class Rogue : AbstractUnit
{
    public Rogue(string name) : base(name, health: 80, power: 15, defense: 5) { }

    public override IBattleCommand Attack(IDamagble target)
        => new AttackCommand(this, target, Weapon);
}
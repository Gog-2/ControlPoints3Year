using BehavioralPatterns.CommandsAttack;
using Charachter.Unit;

namespace BehavioralPatterns.Unit;

public class Archer : AbstractUnit
{
    public Archer(string name) : base(name, health: 90, power: 16, defense: 6) { }

    public override IBattleCommand Attack(IDamagble target)
        => new AttackCommand(this, target, Weapon);
}
using BehavioralPatterns.CommandsAttack;

namespace BehavioralPatterns.Unit;

public class Priest : AbstractUnit
{
    public Priest(string name) : base(name, health: 100, power: 10, defense: 8) { }

    public override IBattleCommand Attack(IDamagble target)
        => new AttackCommand(this, target, Weapon);

    public IBattleCommand HealAlly(AbstractUnit target, int amount)
        => new HealCommand(target, amount);
}
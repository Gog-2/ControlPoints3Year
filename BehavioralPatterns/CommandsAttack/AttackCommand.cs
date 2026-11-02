using BehavioralPatterns.Unit;
using BehavioralPatterns.Weapons;

namespace BehavioralPatterns.CommandsAttack;

public class AttackCommand : IBattleCommand
{
    private readonly AbstractUnit _attacker;
    private readonly IDamagble _target;
    private readonly IWeapon _weapon;
    private int _dealt;
    private bool _executed;

    public AttackCommand(AbstractUnit attacker, IDamagble target, IWeapon weapon)
    {
        _attacker = attacker;
        _target = target;
        _weapon = weapon;
    }

    public bool CanExecute() => !_attacker.IsDead && !_target.IsDead;

    public void Execute()
    {
        if (_executed) return;

        Console.WriteLine($"{_attacker.Name} {_weapon.AttackVerb} {_target.GetType().Name} с {_weapon.Name}!");
        _weapon.OnAttack(_attacker, _target);

        int baseDamage = Math.Min(_target.Health, _attacker.Power);
        _target.TakeDamage(baseDamage);
        _dealt = baseDamage;
        _executed = true;
    }

    public void Undo()
    {
        if (!_executed) return;
        _target.Restore(_dealt);
        _executed = false;
    }
}
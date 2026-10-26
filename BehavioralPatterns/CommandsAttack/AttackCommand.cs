using BehavioralPatterns.Unit;

namespace BehavioralPatterns.CommandsAttack;

public class AttackCommand : IBattleCommand
{
    private readonly AbstractUnit _attacker;
    private readonly IDamagble _target;
    private int _dealt;
    private bool _executed;

    public AttackCommand(AbstractUnit attacker, IDamagble target)
    {
        _attacker = attacker;
        _target = target;
    }

    public bool CanExecute() => !_attacker.IsDead && !_target.IsDead;

    public void Execute()
    {
        if (_executed) return;

        _dealt = Math.Min(_target.Health, _attacker.Power);
        _target.TakeDamage(_dealt);
        _executed = true;
    }

    public void Undo()
    {
        if (!_executed) return;

        _target.Restore(_dealt);
        _executed = false;
    }
}
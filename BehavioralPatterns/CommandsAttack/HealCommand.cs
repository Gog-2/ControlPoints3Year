using BehavioralPatterns.Unit;

namespace BehavioralPatterns.CommandsAttack;

public class HealCommand : IBattleCommand
{
    private readonly AbstractUnit _target;
    private readonly int _amount;
    private bool _executed;

    public HealCommand(AbstractUnit target, int amount)
    {
        _target = target;
        _amount = amount;
    }

    public bool CanExecute() => !_target.IsDead;

    public void Execute()
    {
        if (_executed) return;

        _target.Restore(_amount);
        Console.WriteLine($"{_target.Name} вылечел на {_amount} HP! ({_target.Health} HP)");
        _executed = true;
    }

    public void Undo()
    {
        if (!_executed) return;

        _target.TakeDamage(_amount);
        _executed = false;
    }
}
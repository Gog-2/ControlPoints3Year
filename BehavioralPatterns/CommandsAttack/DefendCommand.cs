using BehavioralPatterns.Unit;

namespace BehavioralPatterns.CommandsAttack;

public class DefendCommand : IBattleCommand
{
    private readonly AbstractUnit _defender;
    private int _previousDefense;
    private bool _executed;

    public DefendCommand(AbstractUnit defender)
    {
        _defender = defender;
    }

    public bool CanExecute() => !_defender.IsDead;

    public void Execute()
    {
        if (_executed) return;

        _previousDefense = _defender.Defense;
        _defender.Defense += _defender.BaseDefenseBonus;
        _executed = true;
        Console.WriteLine($"{_defender.Name} принимает оборонительную позицию! Защита увеличена до {_defender.Defense}");
    }

    public void Undo()
    {
        if (!_executed) return;

        _defender.Defense = _previousDefense;
        _executed = false;
        Console.WriteLine($"{_defender.Name} ослабляет бдительность. Оборона вернулась к {_defender.Defense}");
    }
}
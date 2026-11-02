using BehavioralPatterns.Unit;

namespace BehavioralPatterns.Memento;

public record BattleMemento(
    string TurnDescription,
    Dictionary<string, UnitState> UnitStates,
    List<string> LogEntries
);

public class BattleHistory
{
    private readonly Stack<BattleMemento> _past = new();
    private readonly Stack<BattleMemento> _future = new();

    public void Push(BattleMemento m)
    {
        _past.Push(m);
        _future.Clear();
    }

    public BattleMemento? Undo() => _past.Count > 0 ? _past.Pop() : null;
    public BattleMemento? Redo() => _future.Count > 0 ? _future.Pop() : null;

    public bool CanUndo => _past.Count > 0;
    public bool CanRedo => _future.Count > 0;
}
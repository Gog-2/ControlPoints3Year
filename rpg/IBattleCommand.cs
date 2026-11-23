namespace BehavioralPatterns;

public interface IBattleCommand
{
    public void Execute();
    public void Undo();
}
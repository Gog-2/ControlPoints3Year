using BehavioralPatterns.Unit;

namespace BehavioralPatterns.CommandsAttack;

public class HealCommand : IBattleCommand
{
    private AbstractUnit  _target;
    private int _health;

    public void Init(AbstractUnit target, int health)
    {
        _target = target;
        _health = health;
    }
    
    public void Execute()
    {
        _target.TakeDamage(-_health);
    }

    public void Undo()
    {
        _target.TakeDamage(_health);
    }
}
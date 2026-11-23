using BehavioralPatterns.CommandsAttack;

namespace BehavioralPatterns.Memento;

public class BattleLogger
{
    private readonly List<(int Turn, string Actor, string Action)> _log = new();

    public void Log(int turn, string actor, IBattleCommand cmd)
    {
        string action = cmd switch
        {
            AttackCommand => "Атаковать",
            DefendCommand => "Защитить",
            HealCommand => "Вылечить",
            _ => "Сделать"
        };
        _log.Add((turn, actor, action));
    }

    public void Replay()
    {
        Console.WriteLine("\nИстория битвы");
        foreach (var (turn, actor, action) in _log)
            Console.WriteLine($"Сделал {turn}: {actor} {action}");
    }

    public List<string> GetRecentLog(int count)
        => _log.TakeLast(count).Select(l => $"Сделал {l.Turn}: {l.Actor} {l.Action}").ToList();
}
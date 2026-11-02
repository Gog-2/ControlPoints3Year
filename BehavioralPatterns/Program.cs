using BehavioralPatterns.CommandsAttack;
using BehavioralPatterns.Memento;
using BehavioralPatterns.Unit;
using BehavioralPatterns.Weapons;

namespace BehavioralPatterns;

class Program
{
    private const int TurnsToUndoAvalible = 3;
    
    private static readonly BattleHistory History = new();
    private static readonly BattleLogger Logger = new();
    private static List<AbstractUnit> _party = [];
    private static List<AbstractUnit> _enemies = [];

    static void Main()
    {
        SetupBattle();
        RunArena();
    }

    static void SetupBattle()
    {
        _party =
        [
            new Warrior("Герой") { Weapon = new Sword() },
            new Mage("Маг", 80, 20) { Weapon = new Staff() },
            new Rogue("Разбойник") { Weapon = new Dagger() },
            new Priest("Священник") { Weapon = new Staff() }
        ];

        _enemies =
        [
            new Warrior("Теневой воин") { Weapon = new Sword() },
            new Mage("Тёмный маг", 70, 22) { Weapon = new Staff() },
            new Archer("Фантомный лучник") { Weapon = new Bow() }
        ];

        Console.WriteLine("=== Битва начинается ===\n");
        PrintStatus();
    }

    static void RunArena()
    {
        int turn = 1;

        while (IsTeamAlive(_party) && IsTeamAlive(_enemies))
        {
            Console.WriteLine($"\n--- Ход {turn} ---");

            foreach (var unit in _party.Where(u => !u.IsDead))
            {
                if (!IsTeamAlive(_enemies)) break;

                var cmd = ChooseAction(unit);
                if (cmd is null) continue;
                
                History.Push(CreateMemento(turn, $"{unit.Name}: действие"));
                Logger.Log(turn, unit.Name, cmd);
                cmd.Execute();
            }

            if (!IsTeamAlive(_enemies)) break;

            foreach (var enemy in _enemies.Where(e => !e.IsDead))
            {
                var aliveParty = _party.Where(p => !p.IsDead).ToList();
                if (aliveParty.Count == 0) break;

                var target = aliveParty[Random.Shared.Next(aliveParty.Count)];

                History.Push(CreateMemento(turn, $"{enemy.Name}: атака"));
                var cmd = enemy.Attack(target);
                Logger.Log(turn, enemy.Name, cmd);
                cmd.Execute();
            }

            PrintStatus();

            if (turn % TurnsToUndoAvalible == 0 && History.CanUndo)
            {
                Console.Write("\n[H] История | [U] Откат хода | [Любая клавиша] Далее: ");
                var key = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                switch (key)
                {
                    case 'u':
                        UndoLastTurn();
                        break;
                    case 'h':
                        Logger.Replay();
                        break;
                }
            }

            turn++;
        }

        Console.WriteLine(IsTeamAlive(_party) ? "\n Победа союзников!" : "\n Вся группа пала...");
        Console.WriteLine("\nИтоговый лог сражения:");
        Logger.Replay();
    }

    static IBattleCommand? ChooseAction(AbstractUnit unit)
    {
        while (true)
        {
            Console.WriteLine($"\n{unit.Name} (HP: {unit.Health} | Оружие: {unit.Weapon.Name})");
            Console.WriteLine("1. Атака  2. Защита  3. Лечение  4. Сменить оружие  5. Пропуск");
            Console.Write("> ");

            var input = Console.ReadLine()?.Trim();
            switch (input)
            {
                case "1":
                    return ChooseTarget(unit, _enemies.Where(e => !e.IsDead).ToList(), unit.Attack);

                case "2":
                    return unit.Defend();

                case "3":
                    if (unit is not Priest priest)
                    {
                        Console.WriteLine("Лечить умеет только Священник.");
                        continue;
                    }
                    return ChooseTarget(unit, _party.Where(p => !p.IsDead).ToList(), t => priest.HealAlly((AbstractUnit)t, 25));

                case "4":
                    SwitchWeapon(unit);
                    continue;

                case "5":
                    return null;

                default:
                    Console.WriteLine("Неверный ввод, повторите.");
                    break;
            }
        }
    }

    static IBattleCommand? ChooseTarget(
        AbstractUnit actor,
        List<AbstractUnit> validTargets,
        Func<IDamagble, IBattleCommand> actionFactory)
    {
        if (validTargets.Count == 0) return null;

        Console.WriteLine("Выберите цель:");
        for (int i = 0; i < validTargets.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {validTargets[i].Name} [HP: {validTargets[i].Health}]");
        }

        Console.Write("> ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= validTargets.Count)
        {
            return actionFactory(validTargets[idx - 1]);
        }

        Console.WriteLine("Действие отменено.");
        return null;
    }

    static void SwitchWeapon(AbstractUnit unit)
    {
        IWeapon[] weapons = [new Sword(), new Staff(), new Bow(), new Dagger(), new Fists()];

        Console.WriteLine("\nДоступное оружие:");
        for (int i = 0; i < weapons.Length; i++)
        {
            Console.WriteLine($"  {i + 1}. {weapons[i].Name} (+{weapons[i].DamageBonus} ур., {weapons[i].AttackVerb})");
        }

        Console.Write("> ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= weapons.Length)
        {
            unit.Equip(weapons[idx - 1]);
            Console.WriteLine($"{unit.Name} экипирует: {weapons[idx - 1].Name}");
        }
    }

    static void UndoLastTurn()
    {
        var memento = History.Undo();
        if (memento is null) return;

        foreach (var (name, state) in memento.UnitStates)
        {
            var unit = _party.Concat(_enemies).FirstOrDefault(u => u.Name == name);
            unit?.SetState(state);
        }

        Console.WriteLine("<< Ход успешно откачен");
        PrintStatus();
    }

    static BattleMemento CreateMemento(int turn, string desc) =>
        new(desc, _party.Concat(_enemies).ToDictionary(u => u.Name, u => u.GetState()), Logger.GetRecentLog(5));

    static bool IsTeamAlive(IEnumerable<AbstractUnit> team) => team.Any(u => !u.IsDead);

    static void PrintStatus()
    {
        Console.WriteLine("\n--- Состояние команд ---");
        Console.WriteLine("Союзники: " + string.Join(" | ", _party.Select(p => $"{p.Name}: {(p.IsDead ? "Мёртв" : $"{p.Health} HP")}")));
        Console.WriteLine("Враги:    " + string.Join(" | ", _enemies.Select(e => $"{e.Name}: {(e.IsDead ? "Мёртв" : $"{e.Health} HP")}")));
    }
}
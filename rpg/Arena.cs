using BehavioralPatterns.Unit;
using BehavioralPatterns.Weapons;
using Charachter.Unit;

public class Arena
{
    private const int MaxRound = 15;
    
    private const int MaxCrit = 80;
    private const int CritStep = 5; 
    private const int HpStep = 20;
    private const int HealPercent = 30;
    private const int MaxHeals = 3;
    private const int ExpPerLevel = 50;

    private AbstractUnit _hero;
    private int _maxHp;
    private int _critBonus;
    private int _gold;
    private int _exp;
    private int _level = 1;
    private int _healsLeft = MaxHeals;
    private int _turn = 1;

    private int ExpToNextLevel => ExpPerLevel * _level;

    public void Start()
    {
        Console.Write("Имя: ");
        string name = (Console.ReadLine() ?? "").Trim();
        if (name.Length == 0) name = "Герой";

        _hero = new Warrior(name) { Weapon = new Sword() };
        _maxHp = _hero.Health;
        Console.WriteLine($"\n{_hero.Name} отправляется в путь. HP: {_hero.Health}/{_maxHp}, сила: {_hero.Power}, уровень: {_level}");

        while (!_hero.IsDead)
        {
            Console.WriteLine($"\n=== Ход {_turn} ===");
            var monster = Monster.Generate();
            Console.WriteLine($"Из темноты выходит {monster.Name}: HP {monster.Health}, сила атаки {monster.Power}, награда {monster.Gold} золота");

            if (!Fight(monster)) break;

            Reward(monster);
            
            _turn++;
            if (_turn >= MaxRound) break;
        }

        if (_hero.IsDead)
        {
            _gold = 0;
            Console.WriteLine("\n*** ИГРА ОКОНЧЕНА ***");
            Console.WriteLine("Золото утеряно при смерти.");
        }
        else
        {
            Console.WriteLine($"\n*** ПОБЕДА {_hero.Name} ***");
        }

        Console.WriteLine($"\nИтог: ходов {_turn}, уровень {_level}, золото {_gold}");
    }
    
    private bool Fight(Monster monster)
    {
        while (true)
        {
            var part = ChooseBodyPart();
            
            var attack = Combat.Resolve(_hero.Power, part.HitChance, CritChance(part));
            int monsterHpBefore = monster.Health;
            if (attack.Hit)
            {
                Console.WriteLine($"{_hero.Name} бьёт в {part.Target}{(attack.Crit ? " — КРИТИЧЕСКИЙ УДАР!" : "")}");
                monster.TakeDamage(attack.RawDamage);
            }
            else
            {
                Console.WriteLine($"{_hero.Name} промахивается в {part.Target}.");
            }
            int dealt = monsterHpBefore - monster.Health;

            if (monster.IsDead)
            {
                Console.WriteLine($"{monster.Name} повержен!");
                return true;
            }
            
            var monsterPart = BodyParts.All[Random.Shared.Next(BodyParts.All.Length)];
            var counter = Combat.Resolve(monster.Power, monsterPart.HitChance, monsterPart.CritChance);
            int heroHpBefore = _hero.Health;
            if (counter.Hit)
            {
                Console.WriteLine($"{monster.Name} бьёт в {monsterPart.Target}{(counter.Crit ? " — КРИТИЧЕСКИЙ УДАР!" : "")}");
                _hero.TakeDamage(counter.RawDamage);
            }
            else
            {
                Console.WriteLine($"{monster.Name} промахивается в {monsterPart.Target}.");
            }
            int received = heroHpBefore - _hero.Health;

            Console.WriteLine($"Итог раунда: нанесено {dealt}, получено {received}. HP героя: {_hero.Health}/{_maxHp}");

            if (_hero.IsDead)
            {
                Console.WriteLine($"{_hero.Name} падает...");
                return false;
            }
        }
    }

    private int CritChance(BodyPart p) => Math.Min(MaxCrit, p.CritChance + _critBonus);

    private BodyPart ChooseBodyPart()
    {
        while (true)
        {
            Console.WriteLine("Куда атакуете?");
            for (int i = 0; i < BodyParts.All.Length; i++)
            {
                var p = BodyParts.All[i];
                Console.WriteLine($"  {i + 1}. {p.Label} (попадание {p.HitChance}%, крит {CritChance(p)}%)");
            }

            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= BodyParts.All.Length)
                return BodyParts.All[idx - 1];

            Console.WriteLine("Неверный ввод, повторите.");
        }
    }

    private void Reward(Monster monster)
    {
        int exp = Random.Shared.Next(10, 31);
        _gold += monster.Gold;
        _exp += exp;
        Console.WriteLine($"Награда: +{monster.Gold} золота, +{exp} опыта. Золото: {_gold}, опыт: {_exp}/{ExpToNextLevel}");

        TryHeal();
        
        while (_exp >= ExpToNextLevel)
        {
            _exp -= ExpToNextLevel;
            _level++;
            LevelUp();
        }
    }

    private void TryHeal()
    {
        if (_healsLeft <= 0 || _hero.Health >= _maxHp) return;

        Console.Write($"Восстановить {HealPercent}% HP? (HP: {_hero.Health}/{_maxHp}) [Y/N] (осталось восстановлений: {_healsLeft}): ");
        if ((Console.ReadLine() ?? "").Trim().ToLowerInvariant() != "y") return;

        _healsLeft--;
        _hero.Restore(Math.Min(_maxHp - _hero.Health, _maxHp * HealPercent / 100));
        Console.WriteLine($"HP: {_hero.Health}/{_maxHp}");
    }

    private void LevelUp()
    {
        Console.WriteLine($"\n*** Новый уровень: {_level}! ***");
        bool critAvailable = BodyParts.All.Any(p => p.CritChance + _critBonus < MaxCrit);

        while (true)
        {
            Console.WriteLine("Выберите улучшение:");
            Console.WriteLine($"  1. Здоровье +{HpStep} (макс. сейчас {_maxHp})");
            if (critAvailable)
                Console.WriteLine($"  2. Шанс крита +{CritStep}% всем частям (потолок {MaxCrit}%)");
            Console.Write("> ");

            string input = (Console.ReadLine() ?? "").Trim();

            if (input == "1")
            {
                _maxHp += HpStep;
                _hero.Restore(HpStep);
                Console.WriteLine($"Макс. здоровье: {_maxHp}, HP: {_hero.Health}");
                return;
            }

            if (input == "2" && critAvailable)
            {
                _critBonus += CritStep;
                Console.WriteLine("Шанс крита увеличен.");
                return;
            }

            Console.WriteLine("Неверный ввод, повторите.");
        }
    }
}
using BehavioralPatterns.CommandsAttack;
using BehavioralPatterns.Weapons;

namespace BehavioralPatterns.Unit;

public record UnitState(int Health, int Power, int Defense);

public abstract class AbstractUnit : IDamagble
{
    protected int _health;
    protected string _name;
    protected int _power;
    protected int _defense;
    protected IWeapon _weapon = new Fists();

    public int Health { get => _health; protected set => _health = Math.Max(0, value); }
    public string Name { get => _name; protected set => _name = value; }
    public int Power { get => _power + _weapon.DamageBonus; }
    public int BasePower { get => _power; }
    public int Defense { get => _defense; set => _defense = value; }
    public int BaseDefenseBonus => 3;
    public bool IsDead => Health <= 0;
    public IWeapon Weapon { get => _weapon; set => _weapon = value ?? new Fists(); }

    public AbstractUnit(string name, int health, int power, int defense = 5)
    {
        _name = name;
        _health = health;
        _power = power;
        _defense = defense;
    }

    public void TakeDamage(int amount)
    {
        int mitigated = Math.Max(1, amount - Defense / 2);
        Health -= mitigated;
        Console.WriteLine($"{Name} получил {mitigated} урона! ({Health} Здоровья осталось)");
    }

    public void Restore(int amount) => Health += amount;

    public UnitState GetState() => new(Health, Power, Defense);
    public void SetState(UnitState s) { Health = s.Health; _power = s.Power - _weapon.DamageBonus; Defense = s.Defense; }

    public virtual IBattleCommand Attack(IDamagble target)
        => new AttackCommand(this, target, _weapon);

    public virtual IBattleCommand Defend() => new DefendCommand(this);
    public virtual IBattleCommand Heal(int amount) => new HealCommand(this, amount);

    public void Equip(IWeapon weapon)
    {
        Console.WriteLine($"{Name} взял {weapon.Name}!");
        _weapon = weapon;
    }
}
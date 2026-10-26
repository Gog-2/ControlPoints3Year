using BehavioralPatterns.CommandsAttack;

namespace BehavioralPatterns.Unit;

public record UnitState(int Health, int Power);

public abstract class AbstractUnit : IDamagble
{
        protected int _health;
        protected string _name;
        protected int _power;
        
        public int Health { get => _health; protected set => _health = value; }
        public string Name { get => _name; protected set => _name = value; }
        public int Power { get => _power; protected set => _power = value; }
        public bool IsDead => Health <= 0;

        public AbstractUnit(string name, int health, int power)
        {
                _name = name;
                _health = health;
                _power = power;
        }

        public void TakeDamage(int amount) => Health = Math.Max(0, Health - amount);
        public void Restore(int amount)    => Health += amount;
        
        public UnitState GetState() => new(Health, Power);
        public void SetState(UnitState s) { Health = s.Health; Power = s.Power; }
        
        public virtual IBattleCommand Attack(IDamagble target)
                => new AttackCommand(this, target);
}
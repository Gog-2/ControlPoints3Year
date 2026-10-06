namespace GenerativePatterns
{
    public abstract class Enemy : IDamagble
    {
        protected string _name;
        protected int _startingHealth;
        protected int _health;
        protected Weapon _weapon;
        protected bool _isAlive = true;

        public string Name { get { return _name; } }
        public int Health { get { return _health; } }
        public Weapon Weapon { get { return _weapon; } }
        public bool IsAlive { get { return _isAlive; } }

        public Enemy(string name, int health, Weapon weapon)
        {
            _name = name;
            _startingHealth = health;
            _health = health;
            _weapon = weapon;
        }
        public abstract Enemy GetCloneEnemy(string name);

        public bool TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                _isAlive = false;
                _health = 0;
                Console.WriteLine($"{_name} has been defeated!");
                Console.WriteLine();
                return false;
            }

            else
            {
                Console.WriteLine($"{_name} took {damage} damage and has {_health} health left.");
                Console.WriteLine();
                return true;
            }
        }
    }
}

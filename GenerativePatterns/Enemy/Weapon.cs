namespace GenerativePatterns
{
    public class Weapon
    {
        protected string _name;
        protected int _damage;
        public string Name { get { return _name; } }
        public int Damage { get { return _damage; } }

        public Weapon(string name, int damage)
        {
            _name = name;
            _damage = damage;
        }
    }
}

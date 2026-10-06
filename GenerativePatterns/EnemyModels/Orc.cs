using static GenerativePatterns.EnemyFabric;

namespace GenerativePatterns.EnemyModels
{
    internal class Orc : GenerativePatterns.Enemy
    {
        private EnemyType _type = EnemyType.Orc;
        public Orc(string name, int health, Weapon weapon) : base(name, health, weapon)
        {
        }

        public override Enemy GetCloneEnemy(string name)
        {
            Orc clone = (Orc)this.MemberwiseClone();
            clone._health = _startingHealth;
            clone._isAlive = true;
            clone._name = name;
            return clone;
        }
    }
}

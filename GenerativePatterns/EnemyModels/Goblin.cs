using static GenerativePatterns.EnemyFabric;

namespace GenerativePatterns.EnemyModels
{
    internal class Goblin : GenerativePatterns.Enemy
    {
        private EnemyType _type = EnemyType.Goblin;
        public Goblin(string name, int health, Weapon weapon) : base(name, health, weapon)
        {
        }

        public override Enemy GetCloneEnemy(string name)
        {
            Goblin clone = (Goblin)this.MemberwiseClone();
            clone._health = _startingHealth;
            clone._isAlive = true;
            clone._name = name;
            return clone;
        }
    }
}

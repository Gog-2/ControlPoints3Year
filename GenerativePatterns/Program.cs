using static GenerativePatterns.EnemyFabric;

namespace GenerativePatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Enemy> _enemiesFrendly;
            List<Enemy> _enemies;

            _enemiesFrendly = EnemyFabric.CreateEnemies(
                EnemyType.Goblin,
                4,
                DificultyLevel.Medium);

            _enemies = EnemyFabric.CreateEnemies(
                EnemyType.Orc,
                5,
                DificultyLevel.Medium);

            PrintEnemies(_enemiesFrendly, "Friendly Enemies:");

            PrintEnemies(_enemies, "Friendly Enemies:");


            Console.WriteLine();

            MakeEnemiesAttack(_enemiesFrendly, _enemies);
            MakeEnemiesAttack(_enemiesFrendly, _enemies);
            MakeEnemiesAttack(_enemiesFrendly, _enemies);
            MakeEnemiesAttack(_enemiesFrendly, _enemies);


            PrintEnemies(_enemiesFrendly, "Friendly Enemies:");

            PrintEnemies(_enemies, "Evil Enemies:");

        }
        public static void PrintEnemies(List<Enemy> enemies, string title)
        {
            Console.WriteLine(title);
            foreach (var enemy in enemies)
            {
                Console.WriteLine($"Enemy: {enemy.Name}, Health: {enemy.Health}");
            }
            Console.WriteLine();
        }
        public static void MakeEnemiesAttack(List<Enemy> attackers, List<Enemy> defenders)
        {
            var clonesToCreate = new List<Enemy>();

            foreach (var attacker in attackers.Where(a => a.IsAlive).ToList())
            {
                var target = defenders.FirstOrDefault(d => d.IsAlive);
                    if (target == null) break;

                    target.TakeDamage(attacker.Weapon.Damage);

                    if (!target.IsAlive)
                    {   
                        clonesToCreate.Add(target.GetCloneEnemy($"Clone {target.Name}"));

                        Console.WriteLine($"Enemy {target.Name} died and a clone is prepared!");

                        Console.WriteLine();
                }
            }

            defenders.RemoveAll(e => !e.IsAlive);
            defenders.AddRange(clonesToCreate);
        }

    }
}

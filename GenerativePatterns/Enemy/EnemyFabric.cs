using GenerativePatterns.EnemyModels;

namespace GenerativePatterns
{
    internal class EnemyFabric
    {
        public enum EnemyType
        {
            Orc,
            Goblin
        }
        public enum DificultyLevel
        {
            Easy,
            Medium,
            Hard
        }

        public static List<Enemy> CreateEnemies(
            EnemyType type, 
            int numberOfEnemies, 
            DificultyLevel dificulty)
        {
            List<Enemy> enemies = new List<Enemy>();
            for (int i = 0; i < numberOfEnemies; i++)
            {
                enemies.Add(CreateEnemy(type, i + 1, dificulty));
            }
            return enemies;
        }

        private static Enemy CreateEnemy(
            EnemyType type, 
            int massiveNumber,
            DificultyLevel dificulty)
        {
            switch (type)
            {
                case EnemyType.Orc:
                    return new 
                        
                        Orc(
                        $"Orc {massiveNumber}",
                        HealthRandomizer(dificulty), 
                        new Weapon(
                            "Axe", 
                            DamageRandomizer(dificulty)
                            ));
                
                case EnemyType.Goblin:
                    return new 
                        
                        Goblin
                        ($"Goblin {massiveNumber}",
                        HealthRandomizer(dificulty), 
                        new Weapon(
                            "Dagger", 
                            10)
                        );
               
                default:
                    throw new ArgumentException("Invalid enemy type");
            }
        }

        private static int DamageRandomizer(DificultyLevel dificulty)
        {
            Random random = new Random();
            switch (dificulty)
            {
                case DificultyLevel.Easy:
                    return random.Next(1, 10);
                case DificultyLevel.Medium:
                    return random.Next(10, 20);
                case DificultyLevel.Hard:
                    return random.Next(20, 30);
                default:
                    throw new ArgumentException("Invalid difficulty level");
            }
        }
        private static int HealthRandomizer(DificultyLevel dificulty)
        {
            Random random = new Random();
            switch (dificulty)
            {
                case DificultyLevel.Easy:
                    return random.Next(1, 50);
                case DificultyLevel.Medium:
                    return random.Next(50, 100);
                case DificultyLevel.Hard:
                    return random.Next(100, 150);
                default:
                    throw new ArgumentException("Invalid difficulty level");
            }
        }

    }
}

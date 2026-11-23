using Charachter.Unit;

public class Monster : AbstractUnit
{
    private static readonly string[] Names = { "Гоблин", "Скелет", "Орк", "Волк", "Тролль", "Паук" };

    public Monster(string name, int health, int power, int gold)
        : base(name, health, power, defense: 2)
    {
        Gold = gold;
    }

    public int Gold { get; }

    public static Monster Generate() => new(
        Names[Random.Shared.Next(Names.Length)],
        Random.Shared.Next(30, 81),
        Random.Shared.Next(5, 16),
        Random.Shared.Next(10, 51));
}
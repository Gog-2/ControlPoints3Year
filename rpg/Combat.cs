public readonly record struct AttackResult(bool Hit, bool Crit, int RawDamage);

public static class Combat
{
    public static AttackResult Resolve(int power, int hitChance, int critChance)
    {
        if (Random.Shared.Next(100) >= hitChance)
            return new AttackResult(false, false, 0);

        bool crit = Random.Shared.Next(100) < critChance;

        int spread = Math.Max(1, power / 5);
        int damage = power + Random.Shared.Next(-spread, spread + 1);
        if (crit) damage *= 2;

        return new AttackResult(true, crit, Math.Max(1, damage));
    }
}
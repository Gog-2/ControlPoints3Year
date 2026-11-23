public readonly record struct BodyPart(string Label, string Target, int HitChance, int CritChance);

public static class BodyParts
{
    public static readonly BodyPart Head  = new("Голова",   "голову",   55, 35);
    public static readonly BodyPart Torso = new("Туловище", "туловище", 75, 15);
    public static readonly BodyPart Legs  = new("Ноги",     "ноги",     90,  5);

    public static readonly BodyPart[] All = { Head, Torso, Legs };
}
using System.Numerics;

namespace ObjectBoxingUnboxing.Figure;

public abstract class Figure
{
    public Vector2 Center;

    public Figure(Vector2 center)
    {
        Center = center;
    }
    
    public abstract Vector2 MinPoint { get; }
    public abstract Vector2 MaxPoint { get; }
}
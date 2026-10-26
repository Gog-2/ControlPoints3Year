using System.Numerics;

namespace ObjectBoxingUnboxing.Figure;

public class Circle<T> : Figure
{
    public T Radius { get; private set; }

    public Circle(Vector2 center, T radius) : base(center)
    {
        Radius = radius;
    }
    public void SetRadius<U>(U newRadius)
    {
        Radius = (T)Convert.ChangeType(newRadius, typeof(T));
    }
    
    public double Area
    {
        get
        {
            double r = Convert.ToDouble(Radius);
            return Math.PI * r * r;
        }
    }

    public override Vector2 MinPoint
    {
        get
        {
            float r = (float)Convert.ToDouble(Radius);
            return new Vector2(Center.X - r, Center.Y + r);
        }
    }

    public override Vector2 MaxPoint
    {
        get
        {
            float r = (float)Convert.ToDouble(Radius);
            return new Vector2(Center.X + r, Center.Y - r);
        }
    }
}
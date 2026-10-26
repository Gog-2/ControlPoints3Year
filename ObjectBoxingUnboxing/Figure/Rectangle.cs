using System.Numerics;

namespace ObjectBoxingUnboxing.Figure;

public class Rectangle<TWidth, THeight> : Figure
{
    public TWidth Width { get; private set; }
    public THeight Height { get; private set; }

    public Rectangle(Vector2 center, TWidth width, THeight height) : base(center)
    {
        Width = width;
        Height = height;
    }

    public override Vector2 MinPoint
    {
        get
        {
            float halfW = (float)(Convert.ToDouble(Width) / 2.0);
            float halfH = (float)(Convert.ToDouble(Height) / 2.0);
            return new Vector2(Center.X - halfW, Center.Y + halfH);
        }
    }

    public override Vector2 MaxPoint
    {
        get
        {
            float halfW = (float)(Convert.ToDouble(Width) / 2.0);
            float halfH = (float)(Convert.ToDouble(Height) / 2.0);
            return new Vector2(Center.X + halfW, Center.Y - halfH);
        }
    }
}
using System.Drawing;

namespace SmartHome;

public class Light : BaseSmart
{
    private float _brightness;
    private Color _color;
    

    public float Brightness
    {
        get => _brightness;
        private set => _brightness = value;
    }

    public Color Color
    {
        get => _color;
        private set => _color = value;
    }
    
    public Light()
    {
        _isTurnedOn = false;
    }
    
    public void ChangeBrightness(float brightness)
    {
        Brightness = brightness;
    }

    public void ChangeColor(Color color)
    {
        Color = color;
    }

    public override string ToString()
    {
        return $"Статус: {IsTurnedOn} | Цвет: {Color} | Яркость: {Brightness}";
    }
}
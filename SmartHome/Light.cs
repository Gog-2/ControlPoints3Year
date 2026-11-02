using System.Drawing;

namespace SmartHome;

public class Light
{
    private bool _isTurnedOn;
    private float _brightness;
    private Color _color;

    public bool IsTurnedOn
    {
        get => _isTurnedOn;
        private set => _isTurnedOn = value;
    }

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

    public void SwitchLight()
    {
        IsTurnedOn = !IsTurnedOn;
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
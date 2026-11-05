namespace SmartHome;

public class AirConditioner : BaseSmart
{
    private float _temperature;

    public float Temperature
    {
        get => _temperature;
        protected set => _temperature = value;
    }

    public void SetTemperature(float temperature)
    {
        Temperature = temperature;
    }

    public override string ToString()
    {
        return $"Статус: {IsTurnedOn} ,Температура: {Temperature}";
    }
}
namespace SmartHome;

public class DC_NightMode : DeviceCommand
{
    public DC_NightMode(SmartHomeModel smartHomeModel) : base(smartHomeModel)
    {
    }

    public override void Activate()
    {
        Console.WriteLine();
        
        Console.WriteLine("Light:");
        foreach (Light light in SmartHomeModel._lights)
        {
            light.Switch(false);
            Console.WriteLine(light.ToString());
        }
        
        Console.WriteLine("TV:");
        foreach (TV tv in SmartHomeModel._tvs)
        {
            tv.Switch(false);
            Console.WriteLine(tv.ToString());
        }
        
        Console.WriteLine("AirConditioner:");
        foreach (AirConditioner airCondiconer in SmartHomeModel._airConditioners)
        {
            airCondiconer.Switch(true);
            airCondiconer.SetTemperature(20);
            Console.WriteLine(airCondiconer.ToString());
        }
    }
}
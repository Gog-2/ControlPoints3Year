using System.Drawing;

namespace SmartHome;

public class DC_RedRoom : DeviceCommand
{
    public DC_RedRoom(SmartHomeModel smartHomeModel) : base(smartHomeModel)
    {
    }

    public override void Activate()
    {
        Console.WriteLine();
        
        Console.WriteLine("Light:");
        foreach (Light light in SmartHomeModel._lights)
        {
            light.Switch(true);
            light.ChangeColor(Color.Red);
            light.ChangeBrightness(50f);
            Console.WriteLine(light.ToString());
        }
    }
}
namespace SmartHome;

public class DC_SpeakerLofiHipHop : DeviceCommand
{
    public DC_SpeakerLofiHipHop(SmartHomeModel smartHomeModel) : base(smartHomeModel)
    {
    }

    public override void Activate()
    {
        Console.WriteLine();
        Console.WriteLine("Music Station:");
        foreach (MusicStation station in SmartHomeModel._musicStations)
        {
            station.Switch(true);
            station.SetMusic("LofiHipHop");
            Console.WriteLine(station.ToString());
        }
    }
}
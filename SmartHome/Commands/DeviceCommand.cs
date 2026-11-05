namespace SmartHome;

public abstract class DeviceCommand
{
    protected SmartHomeModel SmartHomeModel;

    public DeviceCommand(SmartHomeModel smartHomeModel)
    {
       SmartHomeModel = smartHomeModel;
    }

    public abstract void Activate();
}
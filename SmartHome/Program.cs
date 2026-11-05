namespace SmartHome;

class Program
{
    static void Main(string[] args)
    {
        SmartHomeModel smartHomeModel = new SmartHomeModel(
            [new Light(), new Light(), new Light()],
            [new TV(), new TV()],
            [new MusicStation()],
            [new AirConditioner(), new AirConditioner()]
        );

        SetUpHome setUpHome = new SetUpHome();
        
        setUpHome.Setup(new DC_NightMode(smartHomeModel));
        setUpHome.Setup(new DC_SpeakerLofiHipHop(smartHomeModel));
        setUpHome.Setup(new DC_RedRoom(smartHomeModel));
    }
}
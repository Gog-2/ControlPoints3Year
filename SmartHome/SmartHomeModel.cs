namespace SmartHome;

public class SmartHomeModel
{
    public List<Light> _lights;
    public List<TV> _tvs;
    public List<MusicStation> _musicStations;
    public List<AirConditioner> _airConditioners;

    public SmartHomeModel(List<Light> lights, 
        List<TV> tvs, 
        List<MusicStation> musicStations, 
        List<AirConditioner> airConditioners)
    {
        _lights = lights;
        _tvs = tvs;
        _musicStations = musicStations;
        _airConditioners = airConditioners;
    }
}
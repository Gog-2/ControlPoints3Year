namespace SmartHome;

public class MusicStation : BaseSmart
{
    private string _music;

    public string Music
    {
        get => _music;
        protected  set { _music = value; }
    }
    
    public void SetMusic(string music)
    {
        Music = music;
    }

    public override string ToString()
    {
        return $"Статус: {IsTurnedOn}, Музыка: {Music}";
    }
    
}
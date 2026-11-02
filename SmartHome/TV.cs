namespace SmartHome;

public class TV
{
    private bool _isTurnedOn;
    private bool _programOn;
    
    public bool IsTurnedOn
    {
        get => _isTurnedOn;
        private set  => _isTurnedOn = value;
    }
    public bool IsProgramOn
    {
        get => _programOn;
        private set => _programOn = value;
    }

    public void SwitchTV()
    {
        IsTurnedOn = !IsTurnedOn;
        if (!IsTurnedOn)
        {
            IsProgramOn = false;
        }
    }
    public void TurnOnProgram()
    {
        if (IsTurnedOn)
        {
            IsProgramOn = !IsProgramOn;
        }
        else
        {
            IsProgramOn = false;
        }
    }

    public override string ToString()
    {
        return $"Состояние: {IsTurnedOn} | Программа: {IsProgramOn}";
    }
}
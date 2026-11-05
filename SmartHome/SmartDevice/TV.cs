namespace SmartHome;

public class TV : BaseSmart
{
    private bool _programOn;
    public bool IsProgramOn
    {
        get => _programOn;
        private set => _programOn = value;
    }

    public override void Switch()
    {
        IsTurnedOn = !IsTurnedOn;
        if (!IsTurnedOn)
        {
            IsProgramOn = false;
        }
    }
    public override void Switch(bool isOn)
    {
        IsTurnedOn = isOn;
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
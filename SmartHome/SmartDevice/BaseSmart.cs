namespace SmartHome;

public class BaseSmart
{
    protected bool _isTurnedOn = false;
    
    public bool IsTurnedOn
    {
        get => _isTurnedOn;
        protected set => _isTurnedOn = value;
    }
    
    public virtual void Switch()
    {
        IsTurnedOn = !IsTurnedOn;
    }
    public virtual void Switch(bool isOn)
    {
        IsTurnedOn = isOn;
    }
}
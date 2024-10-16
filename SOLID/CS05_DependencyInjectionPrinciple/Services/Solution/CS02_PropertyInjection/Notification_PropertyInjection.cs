using CS05_DependencyInjectionPrinciple.Services.Cases.Case2;


namespace CS05_DependencyInjectionPrinciple.Services.Solution.CS01_ConstructorInjection;
public class Notification_PropertyInjection
{
    private IMessenger_Case2 _iMessenger;

    public Notification_PropertyInjection()
    {
    }
    public IMessenger_Case2 MessageService
    {
        get { return _iMessenger; }
        set { _iMessenger = value; }
    }

    public void DoNotify()
    {
        _iMessenger.SendMessage();
    }
}
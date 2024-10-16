using CS05_DependencyInjectionPrinciple.Services.Cases.Case2;


namespace CS05_DependencyInjectionPrinciple.Services.Solution.CS01_ConstructorInjection;

public class Notification_ConstructorInjection
{
    private IMessenger_Case2 _iMessenger;
    public Notification_ConstructorInjection(IMessenger_Case2 pMessenger)
    {
        _iMessenger = pMessenger;
    }
    public void DoNotify()
    {
        _iMessenger.SendMessage();
    }
}
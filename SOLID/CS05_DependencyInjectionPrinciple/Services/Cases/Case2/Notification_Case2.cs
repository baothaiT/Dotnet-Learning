

namespace CS05_DependencyInjectionPrinciple.Services.Cases.Case2;

public class Notification_Case2
{
    private IMessenger_Case2 _iMessenger;
    public Notification_Case2()
    {
        _iMessenger = new Email_Case2();
    }
    public void DoNotify()
    {
        _iMessenger.SendMessage();
    }
}
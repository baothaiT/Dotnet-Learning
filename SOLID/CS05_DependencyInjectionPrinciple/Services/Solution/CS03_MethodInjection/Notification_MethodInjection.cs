using CS05_DependencyInjectionPrinciple.Services.Cases.Case2;

namespace CS05_DependencyInjectionPrinciple.Services.Solution.CS01_ConstructorInjection;

public class Notification_MethodInjection
{
    public void DoNotify(IMessenger_Case2 pMessenger)
    {
        pMessenger.SendMessage();
    }
}
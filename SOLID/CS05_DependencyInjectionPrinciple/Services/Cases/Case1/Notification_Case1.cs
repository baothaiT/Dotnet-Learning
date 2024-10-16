
namespace CS05_DependencyInjectionPrinciple.Services.Cases.Case1;

public class Notification_Case1
{
    private Email_Case1 _email;
    public Notification_Case1()
    {
        _email = new Email_Case1();
    }

    public void PromotionalNotification()
    {
        _email.SendEmail();
    }
}
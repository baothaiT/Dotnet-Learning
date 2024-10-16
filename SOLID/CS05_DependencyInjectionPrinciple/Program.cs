// using CS05_DependencyInjectionPrinciple.Services.Case;
using CS05_DependencyInjectionPrinciple.Services.Cases.Case1;
using CS05_DependencyInjectionPrinciple.Services.Cases.Case2;
using CS05_DependencyInjectionPrinciple.Services.Solution.CS01_ConstructorInjection;


namespace CS05_DependencyInjectionPrinciple;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("CS05_DependencyInjectionPrinciple");

        #region Case 1

        Notification_Case1 notification_Case1 = new Notification_Case1();
        notification_Case1.PromotionalNotification();
            
        #endregion

        #region Case 2
            
        Notification_Case2 notification_Case2 = new Notification_Case2();
        notification_Case2.DoNotify();
        #endregion

        IMessenger_Case2 messenger_Case2 = new Email_Case2();
        #region CS01_ConstructorInjection
        Console.WriteLine("Solution 1  --- CS01_ConstructorInjection");
        Notification_ConstructorInjection notification_ConstructorInjection = new Notification_ConstructorInjection(messenger_Case2);
        notification_ConstructorInjection.DoNotify();
        #endregion

        #region CS02_PropertyInjection
        Console.WriteLine("Solution 2  --- CS02_PropertyInjection");
        Notification_PropertyInjection notification_PropertyInjection = new Notification_PropertyInjection();
        notification_PropertyInjection.MessageService = messenger_Case2;
        notification_PropertyInjection.DoNotify();
        #endregion

        #region CS03_MethodInjection
        Console.WriteLine("Solution 3  --- CS03_MethodInjection");
        Notification_MethodInjection notification_MethodInjection = new Notification_MethodInjection();
        notification_MethodInjection.DoNotify(messenger_Case2);
        #endregion
    }
}

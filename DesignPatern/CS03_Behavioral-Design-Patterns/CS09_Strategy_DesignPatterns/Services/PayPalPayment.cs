

using CS09_Strategy_DesignPatterns.Services.Interfaces;

namespace CS09_Strategy_DesignPatterns.Services;

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} using PayPal.");
    }
}
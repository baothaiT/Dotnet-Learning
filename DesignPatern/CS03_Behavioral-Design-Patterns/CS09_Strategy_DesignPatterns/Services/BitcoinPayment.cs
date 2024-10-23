
using CS09_Strategy_DesignPatterns.Services.Interfaces;

namespace CS09_Strategy_DesignPatterns.Services;
public class BitcoinPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} using Bitcoin.");
    }
}

using CS09_Strategy_DesignPatterns.Services;

namespace CS09_Strategy_DesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, CS09_Strategy_DesignPatterns!");

            decimal amount = 250.00m;

            // Using CreditCardPayment strategy
            PaymentContext context = new PaymentContext(new CreditCardPayment());
            context.ProcessPayment(amount); // Output: Paid $250.00 using Credit Card.

            // Change strategy to PayPalPayment
            context.SetPaymentStrategy(new PayPalPayment());
            context.ProcessPayment(amount); // Output: Paid $250.00 using PayPal.

            // Change strategy to BitcoinPayment
            context.SetPaymentStrategy(new BitcoinPayment());
            context.ProcessPayment(amount); // Output: Paid $250.00 using Bitcoin.
        }
    }
}
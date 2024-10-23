
using CS09_Strategy_DesignPatterns.Services.Interfaces;

namespace CS09_Strategy_DesignPatterns.Services;
public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    // Constructor to set the payment strategy dynamically
    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    // Option to change the strategy at runtime
    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    // Process the payment with the selected strategy
    public void ProcessPayment(decimal amount)
    {
        _paymentStrategy.Pay(amount);
    }
}

using CS04_Decorator_DesignPatterns.Services.Interfaces;

namespace CS04_Decorator_DesignPatterns.Services;
public class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double GetCost()
    {
        return 5.0; // base price of simple coffee
    }
}
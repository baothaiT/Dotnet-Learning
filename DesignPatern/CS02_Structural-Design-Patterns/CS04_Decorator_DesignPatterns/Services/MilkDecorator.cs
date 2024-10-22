using CS04_Decorator_DesignPatterns.AbtractClass;
using CS04_Decorator_DesignPatterns.Services.Interfaces;

namespace CS04_Decorator_DesignPatterns.Services;

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Milk";
    }

    public override double GetCost()
    {
        return _coffee.GetCost() + 1.5; // extra cost for milk
    }
}
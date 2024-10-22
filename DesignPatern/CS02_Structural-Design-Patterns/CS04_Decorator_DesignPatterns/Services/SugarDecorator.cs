
using CS04_Decorator_DesignPatterns.AbtractClass;
using CS04_Decorator_DesignPatterns.Services.Interfaces;

namespace CS04_Decorator_DesignPatterns.Services;
public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Sugar";
    }

    public override double GetCost()
    {
        return _coffee.GetCost() + 0.5; // extra cost for sugar
    }
}
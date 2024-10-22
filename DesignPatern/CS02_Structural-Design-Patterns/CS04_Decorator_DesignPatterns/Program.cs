
using CS04_Decorator_DesignPatterns.Services;
using CS04_Decorator_DesignPatterns.Services.Interfaces;

namespace CS04_Decorator_DesignPatterns;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS04_Decorator_DesignPatterns!");

        // Order a simple coffee
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

        // Add Milk to the coffee
        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

        // Add Sugar to the coffee
        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

        // You can add more decorators if needed
    }
}
using CS01_AbstractFactory_DesignPattern.Services.AbtractService;

namespace CS01_AbstractFactory_DesignPattern.Services;

public class DuckService : BirdAnimalAbtract
{
    public override void Speak()
    {
        Console.WriteLine("Duck says: Quack!");
    }
}
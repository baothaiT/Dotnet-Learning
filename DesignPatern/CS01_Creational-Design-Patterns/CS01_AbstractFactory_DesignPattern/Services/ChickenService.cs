using CS01_AbstractFactory_DesignPattern.Services.AbtractService;

namespace CS01_AbstractFactory_DesignPattern.Services;

public class ChickenService : BirdAnimalAbtract
{
    public override void Speak()
    {
        Console.WriteLine("Chicken says: Cluck!");
    }
}
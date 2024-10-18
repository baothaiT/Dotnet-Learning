using CS01_AbstractFactory_DesignPattern.Services.AbtractService;

namespace CS01_AbstractFactory_DesignPattern.Services;

public class DogService : LandAnimalAbtract
{
    public override void Speak()
    {
        Console.WriteLine("Dog says: Woof!");
    }
}
using CS01_AbstractFactory_DesignPattern.Services.AbtractService;


namespace CS01_AbstractFactory_DesignPattern.Services;

public class CatService : LandAnimalAbtract
{
    public override void Speak()
    {
        Console.WriteLine("Cat says: Meow!");
    }
}
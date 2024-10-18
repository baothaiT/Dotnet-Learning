

using CS01_AbstractFactory_DesignPattern.Factories;
using CS01_AbstractFactory_DesignPattern.Services;
namespace CS01_AbstractFactory_DesignPattern;

public class Client
{
    private readonly IAnimalService _animal1;
    private readonly IAnimalService _animal2;

    public Client(IAnimalFactory factory)
    {
        // _animal1 = factory.CreateAnimal1();
        // _animal2 = factory.CreateAnimal2();
    }

    public void ShowAnimals()
    {
        _animal1.Speak();
        _animal2.Speak();
    }
}
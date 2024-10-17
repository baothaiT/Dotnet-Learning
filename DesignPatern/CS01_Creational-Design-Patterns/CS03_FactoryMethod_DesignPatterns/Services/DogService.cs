
namespace CS03_FactoryMethod_DesignPatterns.Services;

public class DogService : IAnimalService
{
    public void CreateAnimal()
    {
        Console.WriteLine("Dog is created"); 
    }
}
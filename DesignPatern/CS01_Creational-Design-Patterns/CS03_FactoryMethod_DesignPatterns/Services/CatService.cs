
namespace CS03_FactoryMethod_DesignPatterns.Services;

public class CatService : IAnimalService
{
    public void CreateAnimal()
    {
        Console.WriteLine("Cat is created"); 
    }
}
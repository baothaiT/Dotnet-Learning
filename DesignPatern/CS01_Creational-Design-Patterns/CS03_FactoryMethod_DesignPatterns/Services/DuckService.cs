
namespace CS03_FactoryMethod_DesignPatterns.Services;

public class DuckService : IAnimalService
{
    public void CreateAnimal()
    {
        Console.WriteLine("Duck is created"); 
    }
}
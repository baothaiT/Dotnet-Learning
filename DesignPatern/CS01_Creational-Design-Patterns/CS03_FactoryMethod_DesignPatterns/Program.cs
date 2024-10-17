using CS03_FactoryMethod_DesignPatterns.Factory;

namespace CS03_FactoryMethod_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CS03_FactoryMethod_DesignPatterns");

        IAnimalFactory animalFactory = new RandomAnimalFactory();
        for (int i = 0; i < 4; i++)
        {
            
            animalFactory.CreateAnimalFactory().CreateAnimal();
        }
    }
}
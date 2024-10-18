

using CS01_AbstractFactory_DesignPattern.Factories;
using CS01_AbstractFactory_DesignPattern.Services;

namespace CS01_AbstractFactory_DesignPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CS01_AbstractFactory_DesignPattern");

        IAnimalFactory animalService;
        Random random = new Random();
        var index = random.Next(0,2);
        if(index == 0)
        {
            animalService = new BirdFactory();
        }
        else
        {
            animalService = new LandAnimalsFactory();
        }

        animalService.AnimalSpeak().Speak();
        animalService.AnimalSpeak().Speak();
        animalService.AnimalSpeak().Speak();
        animalService.AnimalSpeak().Speak();

        // // Create a factory for land animals
        // IAnimalFactory landFactory = new LandAnimalsFactory();
        // Client landClient = new Client(landFactory);
        // Console.WriteLine("Land animals:");
        // landClient.ShowAnimals();

        // // Create a factory for birds
        // IAnimalFactory birdFactory = new BirdFactory();
        // Client birdClient = new Client(birdFactory);
        // Console.WriteLine("\nBirds:");
        // birdClient.ShowAnimals();
    }
}


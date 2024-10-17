using CS03_FactoryMethod_DesignPatterns.Services;

namespace CS03_FactoryMethod_DesignPatterns.Factory;

public class RandomAnimalFactory : IAnimalFactory
{
    public IAnimalService CreateAnimalFactory()
    {
        Random randomAnimal = new Random();
        var index = randomAnimal.Next(0, 3);

        switch (index)
        {
            case 0:
            return new CatService();
            case 1:
            return new DogService();
            case 2:
            return new DuckService();
            default:
            throw new NotImplementedException();
        }

        
    }
}
using CS01_AbstractFactory_DesignPattern.Services;

namespace CS01_AbstractFactory_DesignPattern.Factories;


public class LandAnimalsFactory : IAnimalFactory
{
    public IAnimalService AnimalSpeak()
    {
        Random random = new Random();
        var index = random.Next(0,2);
        if(index == 0)
        {
            return new DogService();
        }
        else
        {
            return new CatService();
        }
        
    }
}
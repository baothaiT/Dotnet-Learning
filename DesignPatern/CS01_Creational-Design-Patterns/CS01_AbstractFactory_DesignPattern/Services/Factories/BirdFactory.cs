

using CS01_AbstractFactory_DesignPattern.Factories;
using CS01_AbstractFactory_DesignPattern.Services;

namespace CS01_AbstractFactory_DesignPattern.Factories;
public class BirdFactory : IAnimalFactory
{
    public IAnimalService AnimalSpeak()
    {
        Random random = new Random();
        var index = random.Next(0,2);
        if(index == 0)
        {
            return new ChickenService();
        }
        else
        {
            return new DuckService();
        }
        
    }
}
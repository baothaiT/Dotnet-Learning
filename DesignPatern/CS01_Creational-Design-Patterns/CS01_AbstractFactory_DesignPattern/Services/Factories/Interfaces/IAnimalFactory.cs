using CS01_AbstractFactory_DesignPattern.Services;

namespace CS01_AbstractFactory_DesignPattern.Factories;


public interface IAnimalFactory
{
    IAnimalService AnimalSpeak();
}
using CS03_FactoryMethod_DesignPatterns.Services;

namespace CS03_FactoryMethod_DesignPatterns.Factory;

public interface IAnimalFactory
{
    IAnimalService CreateAnimalFactory();
}
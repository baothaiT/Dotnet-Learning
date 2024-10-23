
using CS08_Observer_DesignPatterns.Services.Interfaces;

namespace CS08_Observer_DesignPatterns.Services;

public class MobileDevice : IObserver
{
    private string name;

    public MobileDevice(string name)
    {
        this.name = name;
    }

    public void Update(float temperature)
    {
        Console.WriteLine($"{name} received temperature update: {temperature}°C");
    }
}
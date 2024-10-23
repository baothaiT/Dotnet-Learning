using CS08_Observer_DesignPatterns.Services.Interfaces;

namespace CS08_Observer_DesignPatterns.Services;

public class WebsiteDisplay : IObserver
{
    public void Update(float temperature)
    {
        Console.WriteLine($"Website updated with new temperature: {temperature}°C");
    }
}
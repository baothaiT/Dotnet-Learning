
using CS08_Observer_DesignPatterns.Services.Interfaces;

namespace CS08_Observer_DesignPatterns.Services;
public class LEDDisplayPanel : IObserver
{
    public void Update(float temperature)
    {
        Console.WriteLine($"LED Display shows new temperature: {temperature}°C");
    }
}
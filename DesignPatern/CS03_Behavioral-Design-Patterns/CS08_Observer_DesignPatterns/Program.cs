// See https://aka.ms/new-console-template for more information


using CS08_Observer_DesignPatterns.Services;

namespace CS08_Observer_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS08_Observer_DesignPatterns!");

        // Create a WeatherStation (Subject)
        WeatherStation weatherStation = new WeatherStation();

        // Create observers
        MobileDevice mobile1 = new MobileDevice("Mobile 1");
        MobileDevice mobile2 = new MobileDevice("Mobile 2");
        WebsiteDisplay website = new WebsiteDisplay();
        LEDDisplayPanel ledDisplay = new LEDDisplayPanel();

        // Register observers to the weather station
        weatherStation.RegisterObserver(mobile1);
        weatherStation.RegisterObserver(mobile2);
        weatherStation.RegisterObserver(website);
        weatherStation.RegisterObserver(ledDisplay);

        // Change the temperature and notify observers
        weatherStation.SetTemperature(25.5f);
        weatherStation.SetTemperature(30.0f);

        // Remove one observer and update temperature
        weatherStation.RemoveObserver(mobile2);
        weatherStation.SetTemperature(35.0f);
    }
}
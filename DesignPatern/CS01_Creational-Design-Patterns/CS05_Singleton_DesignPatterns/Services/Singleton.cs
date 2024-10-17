
namespace CS05_Singleton_DesignPatterns.Services;

public class Singleton
{
    // Private static instance of the class (lazily initialized).
    private static Singleton _instance = null;

    // Private constructor to prevent instantiation from outside.
    private Singleton()
    {
        Console.WriteLine("Singleton Instance created.");
    }

    // Public static method to provide access to the instance.
    public static Singleton GetInstance()
    {
        // Create a new instance only if one doesn't exist.
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }

    // An example method to demonstrate the functionality of the Singleton.
    public void DisplayMessage(string message)
    {
        Console.WriteLine($"Message from Singleton: {message}");
    }
}

using CS05_Singleton_DesignPatterns.Services;

namespace CS05_Singleton_DesignPatterns;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("CS05_Singleton_DesignPatterns");

        // Try to get instances of the Singleton class.
        Singleton singleton1 = Singleton.GetInstance();
        Singleton singleton2 = Singleton.GetInstance();

        // Display a message using the Singleton instance.
        singleton1.DisplayMessage("Hello from Singleton!");

        // Check if both variables reference the same instance.
        if (singleton1 == singleton2)
        {
            Console.WriteLine("Both instances are the same.");
        }
        else
        {
            Console.WriteLine("Instances are different.");
        }

        Console.ReadLine();
    }
}
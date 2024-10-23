
using CS01_Chain_Of_Responsibility_DesignPatterns.Services;
using CS01_Chain_Of_Responsibility_DesignPatterns.Services.AbstractClass;

namespace CS01_Chain_Of_Responsibility_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Create the loggers
        Logger errorLogger = new ErrorLogger();
        Logger debugLogger = new DebugLogger();
        Logger infoLogger = new InfoLogger();

        // Set the chain of responsibility
        infoLogger.SetNextLogger(debugLogger);
        debugLogger.SetNextLogger(errorLogger);

        // Messages with different levels
        Console.WriteLine("Sending an INFO level message");
        infoLogger.LogMessage(1, "This is an informational message.");

        Console.WriteLine("\nSending a DEBUG level message");
        infoLogger.LogMessage(2, "This is a debug message.");

        Console.WriteLine("\nSending an ERROR level message");
        infoLogger.LogMessage(3, "This is an error message.");
    }
}
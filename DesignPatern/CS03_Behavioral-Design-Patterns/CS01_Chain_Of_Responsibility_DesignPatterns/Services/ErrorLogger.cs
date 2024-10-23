


using CS01_Chain_Of_Responsibility_DesignPatterns.Services.AbstractClass;

namespace CS01_Chain_Of_Responsibility_DesignPatterns.Services;
class ErrorLogger : Logger
{
    protected override bool CanHandle(int level)
    {
        return level == 3; // Error level
    }

    protected override void Write(string message)
    {
        Console.WriteLine("Error Logger: " + message);
    }
}
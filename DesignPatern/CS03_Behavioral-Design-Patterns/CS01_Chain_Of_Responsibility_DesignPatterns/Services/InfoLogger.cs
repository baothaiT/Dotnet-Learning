


using CS01_Chain_Of_Responsibility_DesignPatterns.Services.AbstractClass;

namespace CS01_Chain_Of_Responsibility_DesignPatterns.Services;
class InfoLogger : Logger
{
    protected override bool CanHandle(int level)
    {
        return level == 1; // Info level
    }

    protected override void Write(string message)
    {
        Console.WriteLine("Info Logger: " + message);
    }
}



using CS01_Chain_Of_Responsibility_DesignPatterns.Services.AbstractClass;

namespace CS01_Chain_Of_Responsibility_DesignPatterns.Services;
class DebugLogger : Logger
{
    protected override bool CanHandle(int level)
    {
        return level == 2; // Debug level
    }

    protected override void Write(string message)
    {
        Console.WriteLine("Debug Logger: " + message);
    }
}
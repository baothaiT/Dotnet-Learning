

namespace CS01_Chain_Of_Responsibility_DesignPatterns.Services.AbstractClass;
public abstract class Logger
{
    protected Logger nextLogger;

    public void SetNextLogger(Logger nextLogger)
    {
        this.nextLogger = nextLogger;
    }

    public void LogMessage(int level, string message)
    {
        if (this.CanHandle(level))
        {
            this.Write(message);
        }
        else if (nextLogger != null)
        {
            nextLogger.LogMessage(level, message);
        }
    }

    // Method to check if the handler can process the request
    protected abstract bool CanHandle(int level);

    // Method to write the log message
    protected abstract void Write(string message);
}
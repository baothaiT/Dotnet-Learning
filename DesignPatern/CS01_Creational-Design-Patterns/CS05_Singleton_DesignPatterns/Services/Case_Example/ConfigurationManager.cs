
namespace CS05_Singleton_DesignPatterns.Services.Case_Example;

public class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private static readonly object _lock = new object();
    public string DatabaseConnectionString { get; private set; }

    private ConfigurationManager()
    {
        // Load configuration from a file or environment
        DatabaseConnectionString = "Server=myServer;Database=myDB;User=myUser;Password=myPass;";
    }

    public static ConfigurationManager GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new ConfigurationManager();
            }
            return _instance;
        }
    }
}

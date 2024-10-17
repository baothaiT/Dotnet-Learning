
namespace CS05_Singleton_DesignPatterns.Services.Case_Example;

public class DatabaseConnectionPool
{
    private static DatabaseConnectionPool _instance;
    private static readonly object _lock = new object();
    private int connectionCount = 0;

    private DatabaseConnectionPool() 
    {
        // Initialize connection pool (e.g., create connections and manage them)
    }

    public static DatabaseConnectionPool GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new DatabaseConnectionPool();
            }
            return _instance;
        }
    }

    public void UseConnection()
    {
        Console.WriteLine("Using a database connection");
        connectionCount++;
    }

    public int GetConnectionCount()
    {
        return connectionCount;
    }
}

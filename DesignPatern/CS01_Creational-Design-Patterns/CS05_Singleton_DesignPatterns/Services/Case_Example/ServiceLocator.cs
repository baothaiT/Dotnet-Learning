
namespace CS05_Singleton_DesignPatterns.Services.Case_Example;

public class ServiceLocator
{
    private static ServiceLocator _instance;
    private static readonly object _lock = new object();
    private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

    private ServiceLocator() { }

    public static ServiceLocator GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new ServiceLocator();
            }
            return _instance;
        }
    }

    public void RegisterService<T>(T service)
    {
        _services[typeof(T)] = service;
    }

    public T GetService<T>()
    {
        return (T)_services[typeof(T)];
    }
}

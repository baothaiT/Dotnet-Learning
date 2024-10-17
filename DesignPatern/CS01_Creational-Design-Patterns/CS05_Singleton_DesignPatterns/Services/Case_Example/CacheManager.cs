
namespace CS05_Singleton_DesignPatterns.Services.Case_Example;

public class CacheManager
{
    private static CacheManager _instance;
    private static readonly object _lock = new object();
    private Dictionary<string, string> _cache = new Dictionary<string, string>();

    private CacheManager() { }

    public static CacheManager GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new CacheManager();
            }
            return _instance;
        }
    }

    public void AddItem(string key, string value)
    {
        if (!_cache.ContainsKey(key))
        {
            _cache[key] = value;
        }
    }

    public string GetItem(string key)
    {
        return _cache.ContainsKey(key) ? _cache[key] : null;
    }
}



using CS06_Flyweight_DesignPatterns.Services.Interfaces;
namespace CS06_Flyweight_DesignPatterns.Services;
public class TreeFactory
{
    private Dictionary<string, ITree> treeTypes = new Dictionary<string, ITree>();

    public ITree GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}-{color}-{texture}";
        
        if (!treeTypes.ContainsKey(key))
        {
            treeTypes[key] = new TreeType(name, color, texture);
        }
        
        return treeTypes[key];
    }
}
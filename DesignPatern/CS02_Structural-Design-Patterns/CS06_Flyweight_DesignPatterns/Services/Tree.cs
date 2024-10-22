

using CS06_Flyweight_DesignPatterns.Services.Interfaces;
namespace CS06_Flyweight_DesignPatterns.Services;
public class Tree
{
    private int x;
    private int y;
    private ITree treeType;

    public Tree(int x, int y, ITree treeType)
    {
        this.x = x;
        this.y = y;
        this.treeType = treeType;
    }

    public void PlantTree()
    {
        treeType.Plant(x, y); // Delegate to flyweight method
    }
}
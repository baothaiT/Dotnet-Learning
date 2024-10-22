

using CS06_Flyweight_DesignPatterns.Services.Interfaces;
namespace CS06_Flyweight_DesignPatterns.Services;
public class TreeType : ITree
{
    private string name;
    private string color;
    private string texture;

    public TreeType(string name, string color, string texture)
    {
        this.name = name;
        this.color = color;
        this.texture = texture;
    }

    public void Plant(int x, int y)
    {
        // Simulate rendering a tree using the extrinsic (location) and intrinsic (type) state
        Console.WriteLine($"Planting a {name} tree of color {color} with texture {texture} at ({x}, {y})");
    }
}


using CS06_Flyweight_DesignPatterns.Services;
using CS06_Flyweight_DesignPatterns.Services.Interfaces;

namespace CS06_Flyweight_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS06_Flyweight_DesignPatterns!");

        TreeFactory factory = new TreeFactory();
        
        // Create many trees with shared intrinsic state (species, color, texture)
        ITree oakTreeType = factory.GetTreeType("Oak", "Green", "Rough");
        ITree pineTreeType = factory.GetTreeType("Pine", "Dark Green", "Smooth");

        // These trees will share the same "Oak" or "Pine" type
        Tree tree1 = new Tree(1, 2, oakTreeType);
        Tree tree2 = new Tree(3, 4, oakTreeType);
        Tree tree3 = new Tree(5, 6, pineTreeType);
        Tree tree4 = new Tree(7, 8, pineTreeType);

        // Plant the trees
        tree1.PlantTree();
        tree2.PlantTree();
        tree3.PlantTree();
        tree4.PlantTree();
    }
}
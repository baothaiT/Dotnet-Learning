

using CS10_Visitor_DesignPatterns.Services;
using CS10_Visitor_DesignPatterns.Services.Interfaces;

namespace CS10_Visitor_DesignPatterns;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS10_Visitor_DesignPatterns!");

        // Create shapes
        IShape circle = new Circle(5);
        IShape rectangle = new Rectangle(10, 20);

        // Create visitors
        IShapeVisitor areaVisitor = new AreaVisitor();
        IShapeVisitor perimeterVisitor = new PerimeterVisitor();

        // Calculate area
        Console.WriteLine("Calculating Areas:");
        circle.Accept(areaVisitor);       // Circle's area
        rectangle.Accept(areaVisitor);    // Rectangle's area

        // Calculate perimeter
        Console.WriteLine("\nCalculating Perimeters:");
        circle.Accept(perimeterVisitor);  // Circle's perimeter
        rectangle.Accept(perimeterVisitor); // Rectangle's perimeter
    }
}

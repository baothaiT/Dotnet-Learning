using CS10_Visitor_DesignPatterns.Services.Interfaces;

namespace CS10_Visitor_DesignPatterns.Services;

public class PerimeterVisitor : IShapeVisitor
{
    public void VisitCircle(Circle circle)
    {
        double perimeter = 2 * Math.PI * circle.Radius;
        Console.WriteLine($"Perimeter of Circle: {perimeter}");
    }

    public void VisitRectangle(Rectangle rectangle)
    {
        double perimeter = 2 * (rectangle.Width + rectangle.Height);
        Console.WriteLine($"Perimeter of Rectangle: {perimeter}");
    }
}
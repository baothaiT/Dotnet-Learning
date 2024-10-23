using CS10_Visitor_DesignPatterns.Services.Interfaces;

namespace CS10_Visitor_DesignPatterns.Services;
public class AreaVisitor : IShapeVisitor
{
    public void VisitCircle(Circle circle)
    {
        double area = Math.PI * Math.Pow(circle.Radius, 2);
        Console.WriteLine($"Area of Circle: {area}");
    }

    public void VisitRectangle(Rectangle rectangle)
    {
        double area = rectangle.Width * rectangle.Height;
        Console.WriteLine($"Area of Rectangle: {area}");
    }
}
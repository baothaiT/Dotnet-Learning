

using CS10_Visitor_DesignPatterns.Services.Interfaces;

namespace CS10_Visitor_DesignPatterns.Services;

public class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.VisitRectangle(this);
    }
}
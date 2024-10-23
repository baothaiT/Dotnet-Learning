
using CS10_Visitor_DesignPatterns.Services.Interfaces;

namespace CS10_Visitor_DesignPatterns.Services;
public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.VisitCircle(this);
    }
}
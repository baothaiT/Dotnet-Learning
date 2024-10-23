

// using CS10_Visitor_DesignPatterns.Services;
namespace CS10_Visitor_DesignPatterns.Services.Interfaces;

public interface IShapeVisitor
{
    void VisitCircle(Circle circle);
    void VisitRectangle(Rectangle rectangle);
}
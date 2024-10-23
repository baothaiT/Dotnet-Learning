
namespace CS10_Visitor_DesignPatterns.Services.Interfaces;

public interface IShape
{
    void Accept(IShapeVisitor visitor);
}
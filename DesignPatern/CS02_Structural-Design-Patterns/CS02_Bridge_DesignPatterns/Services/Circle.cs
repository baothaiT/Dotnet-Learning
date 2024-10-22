
using CS02_Bridge_DesignPatterns.Services.AbstractClass;
using CS02_Bridge_DesignPatterns.Services.Interfaces;

namespace CS02_Bridge_DesignPatterns.Services;
public class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        renderer.Render("Circle");
    }
}
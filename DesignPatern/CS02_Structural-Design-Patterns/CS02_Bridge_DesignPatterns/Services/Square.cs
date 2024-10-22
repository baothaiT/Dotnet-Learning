using CS02_Bridge_DesignPatterns.Services.AbstractClass;
using CS02_Bridge_DesignPatterns.Services.Interfaces;

namespace CS02_Bridge_DesignPatterns.Services;

public class Square : Shape
{
    public Square(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        renderer.Render("Square");
    }
}
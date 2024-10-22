
using CS02_Bridge_DesignPatterns.Services.Interfaces;

namespace CS02_Bridge_DesignPatterns.Services.AbstractClass;
public abstract class Shape
{
    protected IRenderer renderer;

    // Constructor accepts the renderer interface
    public Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    // The shape knows how to draw itself using the renderer
    public abstract void Draw();
}
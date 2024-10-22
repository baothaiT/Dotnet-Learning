
using CS02_Bridge_DesignPatterns.Services.Interfaces;
namespace CS02_Bridge_DesignPatterns.Services;
public class RasterRenderer : IRenderer
{
    public void Render(string shapeName)
    {
        Console.WriteLine($"Drawing {shapeName} as pixels (Raster rendering)");
    }
}
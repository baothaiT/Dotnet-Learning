// See https://aka.ms/new-console-template for more information

using CS02_Bridge_DesignPatterns.Services;
using CS02_Bridge_DesignPatterns.Services.AbstractClass;
using CS02_Bridge_DesignPatterns.Services.Interfaces;

namespace CS02_Bridge_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Use a vector renderer for the circle
        IRenderer vectorRenderer = new VectorRenderer();
        Shape circle = new Circle(vectorRenderer);
        circle.Draw();  // Outputs: Drawing Circle as lines (Vector rendering)

        // Use a raster renderer for the square
        IRenderer rasterRenderer = new RasterRenderer();
        Shape square = new Square(rasterRenderer);
        square.Draw();  // Outputs: Drawing Square as pixels (Raster rendering)

        // You can also switch renderers for the same shape
        circle = new Circle(rasterRenderer);
        circle.Draw();  // Outputs: Drawing Circle as pixels (Raster rendering)
    }
}



using CS03_Composite_DesignPatterns.Services.Interfaces;

namespace CS03_Composite_DesignPatterns.Services;
public class File : IFileSystemItem
{
    private string _name;

    public File(string name)
    {
        _name = name;
    }

    public void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + " File: " + _name);
    }
}


using CS03_Composite_DesignPatterns.Services.Interfaces;

namespace CS03_Composite_DesignPatterns.Services;
public class Folder : IFileSystemItem
{
    private string _name;
    private List<IFileSystemItem> _items = new List<IFileSystemItem>();

    public Folder(string name)
    {
        _name = name;
    }

    public void Add(IFileSystemItem item)
    {
        _items.Add(item);
    }

    public void Remove(IFileSystemItem item)
    {
        _items.Remove(item);
    }

    public void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + " Folder: " + _name);

        // Recursively display child items
        foreach (var item in _items)
        {
            item.Display(depth + 2); // Increase depth for indentation
        }
    }
}
using System.Reflection;

namespace CS32_Directory;

public class Program{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS32_Directory!");

        Console.WriteLine("Path: " + Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

        var currentDirectory = System.IO.Directory.GetCurrentDirectory(); 
        //  string path = Directory.GetCurrentDirectory();
        Console.WriteLine("Path2 : " + currentDirectory);

        var parentDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
        
        Console.WriteLine("Target Path: " + parentDirectory);
    }
}


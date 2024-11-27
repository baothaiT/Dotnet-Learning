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

        // Combine the current directory with the target folder path
        string targetDirectory = Path.Combine(currentDirectory, "Chrome", "Profile");

        Console.WriteLine("Target Directory Combine: " + targetDirectory);

        // Check if the target directory exists, and navigate to it
        if (Directory.Exists(targetDirectory))
        {
            // Change the current directory to the target directory
            Directory.SetCurrentDirectory(targetDirectory);
            Console.WriteLine("Moved to: " + Directory.GetCurrentDirectory());
        }
        else
        {
            Console.WriteLine("Target directory does not exist.");
        }

        var parentDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
        
        Console.WriteLine("Target Path: " + parentDirectory);
    }
}


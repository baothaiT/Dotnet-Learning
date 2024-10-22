// See https://aka.ms/new-console-template for more information
using CS03_Composite_DesignPatterns.Services;
using System;
using System.Collections.Generic;

namespace CS03_Composite_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CS03_Composite_DesignPatterns");

        // Create a folder structure
        Folder root = new Folder("Root");
        root.Add(new Services.File("File1.txt"));
        
        Folder subFolder = new Folder("SubFolder");
        subFolder.Add(new Services.File("File2.txt"));
        subFolder.Add(new Services.File("File3.txt"));
        
        root.Add(subFolder);

        Folder anotherFolder = new Folder("AnotherFolder");
        anotherFolder.Add(new Services.File("File4.txt"));
        
        root.Add(anotherFolder);

        // Display the file structure
        root.Display(1);

        /*
        Expected Output:
        - Folder: Root
        --- File: File1.txt
        --- Folder: SubFolder
        ----- File: File2.txt
        ----- File: File3.txt
        --- Folder: AnotherFolder
        ----- File: File4.txt
        */
    }
}

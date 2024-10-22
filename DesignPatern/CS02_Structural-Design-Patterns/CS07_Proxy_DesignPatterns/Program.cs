


using CS07_Proxy_DesignPatterns.Services;
using CS07_Proxy_DesignPatterns.Services.Interfaces;

namespace CS07_Proxy_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS07_Proxy_DesignPatterns!");

        ISubject document = new DocumentProxy("myBook.pdf");

        // The document will only load when we first try to display it
        Console.WriteLine("Document Proxy created, no loading yet.");
        document.Display();  // Loads the document and displays it
        Console.WriteLine();

        // Further calls do not reload the document
        document.Display();  // Displays the document without loading it again
    }
    
}

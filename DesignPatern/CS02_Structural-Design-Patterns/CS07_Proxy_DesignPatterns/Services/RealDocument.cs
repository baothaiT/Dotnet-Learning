

using CS07_Proxy_DesignPatterns.Services.Interfaces;
namespace CS07_Proxy_DesignPatterns.Services;
public class RealDocument : ISubject
{
    private string _fileName;

    public RealDocument(string fileName)
    {
        _fileName = fileName;
        LoadDocumentFromDisk();  // Simulates an expensive operation
    }

    private void LoadDocumentFromDisk()
    {
        Console.WriteLine("Loading document from disk: " + _fileName);
    }

    public void Display()
    {
        Console.WriteLine("Displaying document: " + _fileName);
    }
}
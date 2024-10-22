

using CS07_Proxy_DesignPatterns.Services.Interfaces;
namespace CS07_Proxy_DesignPatterns.Services;
public class DocumentProxy : ISubject
{
    private string _fileName;
    private RealDocument _realDocument;

    public DocumentProxy(string fileName)
    {
        _fileName = fileName;
    }

    public void Display()
    {
        if (_realDocument == null)
        {
            // Lazily load the real document
            _realDocument = new RealDocument(_fileName);
        }
        _realDocument.Display();
    }
}
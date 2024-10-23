
using CS04_State_DesignPatterns.Services.Interfaces;

namespace CS04_State_DesignPatterns.Services;

public class PublishedState : IDocumentState
{
    public void Publish(Document document)
    {
        Console.WriteLine("Document is already published.");
    }

    public void Edit(Document document)
    {
        Console.WriteLine("Document is published and cannot be edited.");
    }
}

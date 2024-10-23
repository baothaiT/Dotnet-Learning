

using CS04_State_DesignPatterns.Services.Interfaces;

namespace CS04_State_DesignPatterns.Services;

public class ModerationState : IDocumentState
{
    public void Publish(Document document)
    {
        Console.WriteLine("Document is approved and published.");
        document.SetState(new PublishedState());
    }

    public void Edit(Document document)
    {
        Console.WriteLine("Document is under moderation and cannot be edited.");
    }
}

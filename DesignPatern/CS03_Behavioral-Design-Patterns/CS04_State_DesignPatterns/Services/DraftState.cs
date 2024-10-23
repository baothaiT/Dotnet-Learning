

using CS04_State_DesignPatterns.Services.Interfaces;

namespace CS04_State_DesignPatterns.Services;

public class DraftState : IDocumentState
{
    public void Publish(Document document)
    {
        Console.WriteLine("Document is sent for moderation.");
        document.SetState(new ModerationState());
    }

    public void Edit(Document document)
    {
        Console.WriteLine("Document is in Draft state and can be edited.");
    }
}

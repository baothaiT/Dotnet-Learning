

namespace CS04_State_DesignPatterns.Services.Interfaces;

public interface IDocumentState
{
    void Publish(Document document);
    void Edit(Document document);
}

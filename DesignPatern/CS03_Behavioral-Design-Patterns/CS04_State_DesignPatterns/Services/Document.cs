

using CS04_State_DesignPatterns.Services.Interfaces;

namespace CS04_State_DesignPatterns.Services;

public class Document
{
    private IDocumentState _state;

    public Document()
    {
        _state = new DraftState(); // Initial state is Draft
    }

    public void SetState(IDocumentState state)
    {
        _state = state;
    }

    public void Publish()
    {
        _state.Publish(this);
    }

    public void Edit()
    {
        _state.Edit(this);
    }

    public string GetCurrentState()
    {
        return _state.GetType().Name;
    }
}

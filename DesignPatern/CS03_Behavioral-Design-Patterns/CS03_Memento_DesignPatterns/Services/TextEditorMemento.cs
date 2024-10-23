

namespace CS03_Memento_DesignPatterns.Services;

public class TextEditorMemento
{
    public string State { get; private set; }

    public TextEditorMemento(string state)
    {
        State = state;
    }
}
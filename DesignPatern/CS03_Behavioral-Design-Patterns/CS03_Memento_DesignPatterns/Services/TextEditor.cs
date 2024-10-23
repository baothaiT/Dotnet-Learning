
namespace CS03_Memento_DesignPatterns.Services;
public class TextEditor
{
    private string _text;

    public void SetText(string text)
    {
        _text = text;
    }

    public string GetText()
    {
        return _text;
    }

    // Save the current state to a Memento
    public TextEditorMemento SaveState()
    {
        return new TextEditorMemento(_text);
    }

    // Restore the state from a Memento
    public void RestoreState(TextEditorMemento memento)
    {
        _text = memento.State;
    }
}

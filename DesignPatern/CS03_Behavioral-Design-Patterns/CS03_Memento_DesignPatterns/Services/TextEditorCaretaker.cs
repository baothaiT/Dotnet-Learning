

using System.Collections.Generic;
namespace CS03_Memento_DesignPatterns.Services;

public class TextEditorCaretaker
{
    private readonly Stack<TextEditorMemento> _history = new Stack<TextEditorMemento>();

    public void SaveState(TextEditor editor)
    {
        _history.Push(editor.SaveState());
    }

    public void Undo(TextEditor editor)
    {
        if (_history.Count > 0)
        {
            editor.RestoreState(_history.Pop());
        }
    }
}

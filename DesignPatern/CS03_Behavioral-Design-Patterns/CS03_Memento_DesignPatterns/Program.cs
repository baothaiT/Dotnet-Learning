
using CS03_Memento_DesignPatterns.Services;

namespace CS03_Memento_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS03_Memento_DesignPatterns!");

        TextEditor editor = new TextEditor();
        TextEditorCaretaker caretaker = new TextEditorCaretaker();

        editor.SetText("Hello");
        Console.WriteLine("Current Text: " + editor.GetText());

        // Save the current state
        caretaker.SaveState(editor);

        editor.SetText("Hello, World!");
        Console.WriteLine("After Modification: " + editor.GetText());

        // Undo the change
        caretaker.Undo(editor);
        Console.WriteLine("After Undo: " + editor.GetText());
    }
}



using CS06_Command_DesignPatterns.Services.Interfaces;

namespace CS06_Command_DesignPatterns.Services;

// The Invoker: Remote Control
public class RemoteControl
{
    private ICommand _command;

    // Set the command
    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    // Execute the command
    public void PressButton()
    {
        _command.Execute();
    }

    // Undo the last command
    public void PressUndo()
    {
        _command.Undo();
    }
}
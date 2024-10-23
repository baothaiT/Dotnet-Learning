

namespace CS06_Command_DesignPatterns.Services.Interfaces;

public interface ICommand
{
    void Execute();
    void Undo();  // Optional: To allow undoing of commands
}
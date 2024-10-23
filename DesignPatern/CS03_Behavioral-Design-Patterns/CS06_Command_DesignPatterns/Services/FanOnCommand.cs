

using CS06_Command_DesignPatterns.Services.Interfaces;

namespace CS06_Command_DesignPatterns.Services;

public class FanOnCommand : ICommand
{
    private Fan _fan;

    public FanOnCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.TurnOn();
    }

    public void Undo()
    {
        _fan.TurnOff();
    }
}
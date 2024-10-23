
using CS06_Command_DesignPatterns.Services.Interfaces;

namespace CS06_Command_DesignPatterns.Services;
// Command to turn off the fan
public class FanOffCommand : ICommand
{
    private Fan _fan;

    public FanOffCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.TurnOff();
    }

    public void Undo()
    {
        _fan.TurnOn();
    }
}
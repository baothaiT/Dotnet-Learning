

using CS06_Command_DesignPatterns.Services.Interfaces;

namespace CS06_Command_DesignPatterns.Services;
// Command to turn off the light
public class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }

    public void Undo()
    {
        _light.TurnOn();
    }
}
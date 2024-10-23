// See https://aka.ms/new-console-template for more information

using CS06_Command_DesignPatterns.Services;
using CS06_Command_DesignPatterns.Services.Interfaces;

namespace CS06_Command_DesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, CS06_Command_DesignPatterns!");

            // Receivers
            Light livingRoomLight = new Light();
            Fan ceilingFan = new Fan();

            // Concrete Commands
            ICommand lightOnCommand = new LightOnCommand(livingRoomLight);
            ICommand lightOffCommand = new LightOffCommand(livingRoomLight);
            ICommand fanOnCommand = new FanOnCommand(ceilingFan);
            ICommand fanOffCommand = new FanOffCommand(ceilingFan);

            // Invoker: Remote Control
            RemoteControl remote = new RemoteControl();

            // Turn the light on
            remote.SetCommand(lightOnCommand);
            remote.PressButton();

            // Turn the light off
            remote.SetCommand(lightOffCommand);
            remote.PressButton();

            // Undo the last command (turn the light back on)
            remote.PressUndo();

            // Turn the fan on
            remote.SetCommand(fanOnCommand);
            remote.PressButton();

            // Turn the fan off
            remote.SetCommand(fanOffCommand);
            remote.PressButton();

            // Undo the last command (turn the fan back on)
            remote.PressUndo();
        }
    }
}
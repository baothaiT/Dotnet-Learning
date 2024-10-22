
namespace CS05_Facade_DesignPatterns.Serivces;
public class SoundSystem
{
    public void TurnOn()
    {
        Console.WriteLine("Sound system is turned ON");
    }

    public void SetVolume(int level)
    {
        Console.WriteLine($"Sound system volume set to {level}");
    }

    public void TurnOff()
    {
        Console.WriteLine("Sound system is turned OFF");
    }
}
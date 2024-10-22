
namespace CS05_Facade_DesignPatterns.Serivces;
public class HomeTheaterFacade
{
    private TV _tv;
    private SoundSystem _soundSystem;
    private DVDPlayer _dvdPlayer;

    public HomeTheaterFacade(TV tv, SoundSystem soundSystem, DVDPlayer dvdPlayer)
    {
        _tv = tv;
        _soundSystem = soundSystem;
        _dvdPlayer = dvdPlayer;
    }

    // Simplified method to turn on the home theater
    public void WatchMovie()
    {
        Console.WriteLine("Starting home theater...");
        _tv.TurnOn();
        _soundSystem.TurnOn();
        _soundSystem.SetVolume(10);
        _dvdPlayer.InsertDVD();
        _dvdPlayer.Play();
        Console.WriteLine("Enjoy your movie!");
    }

    // Simplified method to turn off the home theater
    public void EndMovie()
    {
        Console.WriteLine("Shutting down home theater...");
        _dvdPlayer.Eject();
        _tv.TurnOff();
        _soundSystem.TurnOff();
    }
}
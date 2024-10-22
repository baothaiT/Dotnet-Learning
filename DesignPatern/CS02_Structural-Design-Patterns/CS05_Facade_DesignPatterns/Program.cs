

using CS05_Facade_DesignPatterns.Serivces;

namespace CS05_Facade_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS05_Facade_DesignPatterns!");
        // Create instances of subsystems
        TV tv = new TV();
        SoundSystem soundSystem = new SoundSystem();
        DVDPlayer dvdPlayer = new DVDPlayer();

        // Create the facade
        HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, soundSystem, dvdPlayer);

        // Use the facade to watch a movie
        homeTheater.WatchMovie();

        Console.WriteLine(); // for separation

        // Use the facade to turn off the home theater
        homeTheater.EndMovie();

        Console.ReadLine();
    }
}

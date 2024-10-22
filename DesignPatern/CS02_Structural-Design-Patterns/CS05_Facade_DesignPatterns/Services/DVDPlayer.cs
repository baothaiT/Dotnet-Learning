
namespace CS05_Facade_DesignPatterns.Serivces;
public class DVDPlayer
{
    public void InsertDVD()
    {
        Console.WriteLine("DVD is inserted");
    }

    public void Play()
    {
        Console.WriteLine("DVD is playing");
    }

    public void Eject()
    {
        Console.WriteLine("DVD is ejected");
    }
}
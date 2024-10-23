
using CS07_Mediator_DesignPatterns.Services.Abstract;
using CS07_Mediator_DesignPatterns.Services.Interfaces;

namespace CS07_Mediator_DesignPatterns.Services;
public class Admin : Participant
{
    public Admin(string name, IChatRoomMediator chatRoom) : base(name, chatRoom) { }

    public override void Receive(string message)
    {
        Console.WriteLine($"{Name} (Admin) received: {message}");
    }
}
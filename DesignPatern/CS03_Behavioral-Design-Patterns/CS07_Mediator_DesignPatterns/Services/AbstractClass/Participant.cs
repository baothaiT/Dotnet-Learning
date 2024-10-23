
using CS07_Mediator_DesignPatterns.Services.Interfaces;

namespace CS07_Mediator_DesignPatterns.Services.Abstract;
public abstract class Participant
{
    protected IChatRoomMediator chatRoom;
    public string Name { get; private set; }

    public Participant(string name, IChatRoomMediator chatRoom)
    {
        Name = name;
        this.chatRoom = chatRoom;
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        chatRoom.SendMessage(message, this);
    }

    public abstract void Receive(string message);
}
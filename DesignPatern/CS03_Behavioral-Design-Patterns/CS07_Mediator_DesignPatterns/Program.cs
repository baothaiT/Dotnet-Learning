// See https://aka.ms/new-console-template for more information


using CS07_Mediator_DesignPatterns.Services;
using CS07_Mediator_DesignPatterns.Services.Abstract;
using CS07_Mediator_DesignPatterns.Services.Interfaces;

namespace CS07_Mediator_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS07_Mediator_DesignPatterns!");

        // Create mediator
        IChatRoomMediator chatRoom = new ChatRoom();

        // Create participants
        Participant user1 = new User("John", chatRoom);
        Participant user2 = new User("Jane", chatRoom);
        Participant admin = new Admin("Admin", chatRoom);

        // Register participants to the chat room
        chatRoom.RegisterParticipant(user1);
        chatRoom.RegisterParticipant(user2);
        chatRoom.RegisterParticipant(admin);

        // Participants sending messages
        user1.Send("Hello, everyone!");
        user2.Send("Hi, John!");
        admin.Send("Please keep the chat clean.");
    }
}


using CS07_Mediator_DesignPatterns.Services.Abstract;
using CS07_Mediator_DesignPatterns.Services.Interfaces;

namespace CS07_Mediator_DesignPatterns.Services;
public class ChatRoom : IChatRoomMediator
{
    private List<Participant> participants = new List<Participant>();

    public void RegisterParticipant(Participant participant)
    {
        participants.Add(participant);
    }

    public void SendMessage(string message, Participant participant)
    {
        foreach (var p in participants)
        {
            // Message should not be received by the sender
            if (p != participant)
            {
                p.Receive(message);
            }
        }
    }
}


using CS07_Mediator_DesignPatterns.Services.Abstract;

namespace CS07_Mediator_DesignPatterns.Services.Interfaces;

public interface IChatRoomMediator
{
    void SendMessage(string message, Participant participant);
    void RegisterParticipant(Participant participant);
}

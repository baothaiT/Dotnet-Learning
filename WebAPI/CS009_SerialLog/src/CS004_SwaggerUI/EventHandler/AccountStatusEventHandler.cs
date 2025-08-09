using System;
using CS004_SwaggerUI.Events;

namespace CS004_SwaggerUI.EventHandler;

public class AccountStatusEventHandler : IEventHandler<AccountStatusEvent>
{
    public void Handle(AccountStatusEvent domainEvent)
    {
        Console.WriteLine($"📧 Sending email successfully to user: {domainEvent.User.Email}");
    }
}
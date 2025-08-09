using System;
using CS004_SwaggerUI.Entities;

namespace CS004_SwaggerUI.Events;

public class AccountStatusEvent : IDomainEvent
{
    public UserEntity User { get; }

    public AccountStatusEvent(UserEntity user)
    {
        User = user ?? throw new ArgumentNullException(nameof(user), "User cannot be null");
    }
}

using System;

namespace CS004_SwaggerUI.EventHandler;

public interface IEventHandler<in T> where T : class
{
    void Handle(T domainEvent);
}

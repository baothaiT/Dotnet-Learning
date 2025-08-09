using System;

namespace CS004_SwaggerUI.EventHandler;

public interface IEventDispatcher
{
    public void Dispatch(IEnumerable<object> domainEvents);
}

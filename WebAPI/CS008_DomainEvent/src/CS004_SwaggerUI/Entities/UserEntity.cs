
using CS004_SwaggerUI.Events;
namespace CS004_SwaggerUI.Entities;

public class UserEntity : BaseEntity
{
    internal UserEntity() { }

    public UserEntity(string username, string email, string passwordHash)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        Status = Status.New;
    }

    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Status Status { get; set; }

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void SetStatus(Status newStatus)
    {
        // if (Status == newStatus) return;

        Status = newStatus;
        AddDomainEvent(new AccountStatusEvent(this));
    }

    private void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
} 


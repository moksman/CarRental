namespace CarRental.Core.Abstractions;

public abstract class Entity<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public TId Id { get; private set; }

    protected Entity(TId id)
    {
        Id = id;
    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}



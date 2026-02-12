using Starter.Domain.Primitives.Events;

namespace Starter.Domain.Primitives.Entities;

public interface IAggregateRoot
{
    IReadOnlyList<IDomainEvent> DomainEventQueue { get; }
    void ClearDomainEvents();
    bool HasDomainEvents();
}

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    public IReadOnlyList<IDomainEvent> DomainEventQueue => _domainEventQueue.AsReadOnly();

    private readonly List<IDomainEvent> _domainEventQueue = [];

    protected void AddDomainEvent(IDomainEvent @event) => _domainEventQueue.Add(@event);

    public void ClearDomainEvents() => _domainEventQueue.Clear();

    public bool HasDomainEvents() => _domainEventQueue.Count > 0;
}

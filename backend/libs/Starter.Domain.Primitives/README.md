# Starter.Domain.Primitives

Portable DDD building blocks .NET - zero dependencies.

## What's Inside

- **Entity** - Base class with Id, timestamps, equality
- **AggregateRoot** - Entity + domain events queue
- **Result Pattern** - `Result<T>` for error handling
- **Domain Events** - `IDomainEvent`, `IDomainEventHandler`, `IDomainEventDispatcher`

## Quick Start

**Entity:**
```csharp
public class User : Entity
{
    public string Name { get; private set; }
}
```

**Aggregate Root:**
```csharp
public class Order : AggregateRoot
{
    public void Complete()
    {
        AddDomainEvent(new OrderCompletedEvent(Id));
    }
}
```

**Result Pattern:**
```csharp
public Result<User> CreateUser(string name)
{
    if (string.IsNullOrEmpty(name))
        return Result<User>.Fail(new Exception("Name required"));
    
    return Result<User>.Ok(new User(name));
}
```

**Domain Events:**
```csharp
public record OrderCompletedEvent(Guid OrderId) : IDomainEvent;

public class OrderCompletedHandler : IDomainEventHandler<OrderCompletedEvent>
{
    public Task HandleAsync(OrderCompletedEvent @event, CancellationToken ct)
    {
        // Handle event
    }
}
```

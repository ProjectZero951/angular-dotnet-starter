# Starter.Mediator.Core

Lightweight CQS/CQRS for .NET - zero dependencies (except DI.Abstractions).

## Quick Start

**1. Define Request:**
```csharp
public sealed record GetUserQuery(Guid UserId);
```

**2. Create Handler:**
```csharp
public class GetUserHandler(IRepo repo) : RequestHandler<GetUserQuery, Result<UserDto>>
{
    public override async ValueTask<Result<UserDto>> Handle(GetUserQuery query, CancellationToken ct)
    {
        var user = await repo.GetById(query.UserId, ct);
        return Result<UserDto>.Ok(user);
    }
}
```

**3. Register:**
```csharp
services.AddMediator<GetUserHandler>();  // Auto-discovers assembly and registers all handlers
```

**4. Use:**
```csharp
// Controller
var request = new Command<CreateUserCmd, Result<Guid>>(command); // Modification
var request = new Query<GetUserQuery, Result<UserDto>>(query);   // Read-only
var result = await dispatcher.Send(request, ct);
```

## PreExecute Hook

```csharp
public override async Task PreExecute(IRequest<MyCmd, Result> req, CancellationToken ct)
{
    if (string.IsNullOrEmpty(req.Value.Data))
        throw new ValidationException("Data required");
}
```

## Key Features

- ✅ Type-safe generics
- ✅ Zero runtime reflection
- ✅ Command/Query markers (ICommand/IQuery)
- ✅ PreExecute hook
- ✅ Portable (1 dependency)


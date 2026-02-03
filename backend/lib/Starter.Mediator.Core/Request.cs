namespace Starter.Mediator.Core;


public interface IRequest;

public interface ICommand : IRequest;

public interface IQuery : IRequest;

public interface IRequest<T> : IRequest;

public interface IRequest<out TRequest, TResult>
{
    TRequest Value { get; }
    DateTime CreatedAt { get; }
    Guid CorrelationId { get; }
}

public abstract class Request<TRequest, TResult>(TRequest value, Guid? correlationId = null) : IRequest<TRequest, TResult>
{
    public TRequest Value { get; } = value;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public Guid CorrelationId { get; } = correlationId ?? Guid.NewGuid();
}

public sealed class Command<TRequest, TResult>(TRequest value, Guid? correlationId = null)
    : Request<TRequest, TResult>(value, correlationId), ICommand;

public sealed class Query<TRequest, TResult>(TRequest value, Guid? correlationId = null)
    : Request<TRequest, TResult>(value, correlationId), IQuery;

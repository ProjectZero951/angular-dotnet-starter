namespace Starter.Mediator.Core;


public interface IRequestHandler<TRequest, TRequestType, TResult>
    where TRequest : IRequest<TRequestType, TResult>
{
    Task<TResult> HandleAsync(TRequest request, CancellationToken token = default);

    Task PreExecute(TRequest request, CancellationToken token = default) => Task.CompletedTask;

    Task<IRequestHandler<TRequest, TRequestType, TResult>> PreExecuteAsync(TRequest request, CancellationToken ct = default);
}

public abstract class RequestHandler<TRequest, TResult>
    : IRequestHandler<IRequest<TRequest, TResult>, TRequest, TResult>
{
    public abstract ValueTask<TResult> Handle(TRequest request, CancellationToken cancellationToken);

    public async Task<TResult> HandleAsync(IRequest<TRequest, TResult> request, CancellationToken token = default) => await Handle(request.Value, token);

    public virtual Task PreExecute(IRequest<TRequest, TResult> request, CancellationToken token = default) => Task.CompletedTask;

    public async Task<IRequestHandler<IRequest<TRequest, TResult>, TRequest, TResult>> PreExecuteAsync(
        IRequest<TRequest, TResult> request, CancellationToken ct = default)
    {
        await PreExecute(request, ct);
        return this;
    }
}

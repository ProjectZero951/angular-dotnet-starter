namespace Starter.Mediator.Core;


public interface IDispatcher
{
    Task<TResult> Send<TRequest, TResult>(IRequest<TRequest, TResult> request, CancellationToken cancellationToken = default);
}

public sealed class Dispatcher(IServiceProvider serviceProvider) : IDispatcher
{
    public Task<TResult> Send<TRequest, TResult>(
        IRequest<TRequest, TResult> request,
        CancellationToken cancellationToken = default)
        => serviceProvider
            .GetService<IRequestHandler<IRequest<TRequest, TResult>, TRequest, TResult>>()?
            .PreExecuteAsync(request, cancellationToken)
            .HandleAsync(request, cancellationToken)
        ?? throw new InvalidOperationException(
            $"No handler registered for {typeof(IRequestHandler<IRequest<TRequest, TResult>, TRequest, TResult>).Name}");
}

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Starter.Mediator.Core;

public static class Extensions
{
    public static T? GetService<T>(this IServiceProvider provider) => (T?)provider.GetService(typeof(T));

    public static IServiceCollection AddMediator<TMarker>(this IServiceCollection services)
        => AddMediator(services, typeof(TMarker).Assembly);

    public static IServiceCollection AddMediator(this IServiceCollection services, Assembly handlersAssembly)
    {
        services.AddScoped<IDispatcher, Dispatcher>();

        var handlerTypes = handlersAssembly.GetTypes()
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IRequestHandler<,,>)))
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            var handlerInterfaces = handlerType.GetInterfaces()
                .Where(i => i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IRequestHandler<,,>));

            foreach (var handlerInterface in handlerInterfaces)
            {
                services.AddScoped(handlerInterface, handlerType);
            }
        }

        return services;
    }

    public static async Task<TResult> HandleAsync<TRequest, TRequestType, TResult>(
        this Task<IRequestHandler<TRequest, TRequestType, TResult>> task, TRequest request,
        CancellationToken ct = default)
        where TRequest : IRequest<TRequestType, TResult>
        => await (await task).HandleAsync(request, ct);
}
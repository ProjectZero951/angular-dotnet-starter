using Microsoft.Extensions.DependencyInjection;

namespace Starter.Infrastructure;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure()
        {
            return services;
        }
    }
}

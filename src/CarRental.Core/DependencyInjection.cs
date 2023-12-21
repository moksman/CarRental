using CarRental.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Core;

public static class DependencyInjection
{
    //public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    public static IServiceCollection ConfigureDomainServices<TId>(this IServiceCollection services)
    {
        services.AddScoped<ICarService<TId>, CarService<TId>>();

        return services;
    }
}

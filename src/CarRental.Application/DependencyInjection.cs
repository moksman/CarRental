using CarRental.Application.UseCases.Car.Get;
using CarRental.Application.UseCases.City.Get;
using CarRental.Core.Model;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CarRental.Application;

public static class DependencyInjection
{
    //public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    public static IServiceCollection ConfigureApplicationLayer<TId>(this IServiceCollection services)
    {
        var assembly = typeof(GetAllCarQueryHandler<>).GetTypeInfo().Assembly;

        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly))
            .AddTransient<IRequestHandler<GetAllCarQuery<int>, IEnumerable<Car<int>>>, GetAllCarQueryHandler<int>>()
            .AddTransient<IRequestHandler<GetCarByCityQuery<int>, IEnumerable<Car<int>>>, GetCarByCityQueryHandler<int>>()
            .AddTransient<IRequestHandler<GetAllCityQuery<int>, IEnumerable<City<int>>>, GetAllCItyQueryHandler<int>>();


        return services;
    }
}

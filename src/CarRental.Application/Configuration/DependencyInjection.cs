using CarRental.Application.Services;
using CarRental.Application.UseCases.Car;
using CarRental.Application.UseCases.Car.Queries.Get;
using CarRental.Application.UseCases.City.Queries.Get;
using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CarRental.Application.Configuration;

public static class DependencyInjection
{
    //public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services)
    {
        var assembly = typeof(GetAllCarQueryHandler).GetTypeInfo().Assembly;

        //services
        //    .AddScoped<IGenericService<Car>, GenericService<Car>>()
        //    .AddScoped<IGenericService<City>, GenericService<City>>();

        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly))
            .AddTransient<IRequestHandler<GetAllCarQuery, IEnumerable<CarDto>>, GetAllCarQueryHandler>()
            .AddTransient<IRequestHandler<GetCarByCityQuery, IEnumerable<CarDto>>, GetCarByCityQueryHandler>()
            .AddTransient<IRequestHandler<GetAllCityQuery, IEnumerable<CityDto>>, GetAllCityQueryHandler>()
            .AddTransient<CarMapper>()
            .AddTransient<CityMapper>();


        return services;
    }
}

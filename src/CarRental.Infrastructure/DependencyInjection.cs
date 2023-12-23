using CarRental.Application.Interfaces;
using CarRental.Application.UseCases.Car.Get;
using CarRental.Core.Model;
using CarRental.Infrastructure.Data;
using CarRental.Infrastructure.Data.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace CarRental.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigurePersistance<TId>(this IServiceCollection services, IConfiguration configuration) //where TId : class
    {
        //services.AddDbContext<AppDbContext>();

        //moved configuration to dbcontext class so that migration will run
        services.AddDbContext<AppDbContext<TId>>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            //options.UseSqlite($"Data Source={System.IO.Path.Join(
            //        Environment.GetFolderPath(
            //            Environment.SpecialFolder.LocalApplicationData), "WeatherForecast.db")}");

            //options.UseInMemoryDatabase(databaseName: "WeatherForecastDb");
        });

        services
            .AddScoped<IBaseRepository<Car<TId>, TId>, BaseRepository<Car<TId>, TId>>()
            .AddScoped<IBaseRepository<City<TId>, TId>, BaseRepository<City<TId>, TId>>()
            .AddScoped<IListCarQueryService<TId>, ListCarQueryService<TId>>();

        return services;
    }

    public static IServiceCollection AddData<TId>(this IServiceCollection services)
    {
        var sp = services.BuildServiceProvider();

        var dbcontext = (AppDbContext<int>)sp.GetService(typeof(AppDbContext<int>));

        dbcontext.Database.EnsureDeleted();
        dbcontext.Database.EnsureCreated();


        dbcontext.Cities.AddRange(
            new City<int>
            {
                Name = "Prague",
            },
            new City<int>
            {
                Name = "Brno",
            },
            new City<int>
            {
                Name = "Liberec",
            },
            new City<int>
            {
                Name = "Pardubice",
            });

        dbcontext.Cars.AddRange(
            new Car<int>
            {
                CityId = 1,
                Brand = "Audi",
                Model = "RS6",
                Description = "Easy Link 7” –multimediasystem med 7-tums högupplöst pekskärm – kompatibel med Android Auto™ och Apple CarPlay – sex högtalare, Bluetooth®, två USB-uttag, ett AUX-uttag Manuell luftkonditionering Aktiv panikbromsning med fotgängar- och cyklistavkänning (AEBS City + Inter Urbain) Filbytesvarnare och Filhållarassistans",
                Image = "/images/cars/audi_rs6.webp"
            },
            new Car<int>
            {
                CityId = 1,
                Brand = "Audi",
                Model = "RS8",
                Description = "Lyssna på det här: 550 hästkrafter, elektrisk xDrive, och 0-100 km/h på 3,9 sekunder. BMW i4 är helt enkelt elbilen för dig som älskar att köra. Här får du uppleva sportig prestanda i förstklassig komfort. Bakhjuls- eller fyrhjulsdrivet väljer du själv. Med 590 kilometers räckvidd och bagageutrymme som en halvkombi får du en flexibel kompanjon på långresan. Klara, färdiga, njut!",
                Image = "/images/cars/audi_rs8.webp"
            },
            new Car<int>
            {
                CityId = 1,
                Brand = "BENTLEY",
                Model = "CONTINENTAL GT",
                Description = "Genom att addera elkraft får du en laddhybrid som tar hänsyn till morgondagen, utan att kompromissa med körupplevelsen.",
                Image = "/images/cars/BENTLEY_CONTINENTAL_GT.webp"
            },
            new Car<int>
            {
                CityId = 1,
                Brand = "lambo",
                Model = "urus",
                Description = "Interiören i Audi Q4 e-tron präglas av innovativ teknik, sportighet och funktionalitet – som Audi virtual cockpit som ingår som standard.",
                Image = "/images/cars/lambo_urus.webp"
            },
            new Car<int>
            {
                CityId = 1,
                Brand = "Mercedes",
                Model = "G63",
                Description = "Upptäck Peugeot 3008 och dess unika revolutionerande stil. Med Peugeot i-Cockpit® och innovativ teknik i framkant förstärks ditt välbefinnande, din säkerhet och din komfort. ",
                Image = "/images/cars/mercedes_g63.webp"
            },
            new Car<int>
            {
                CityId = 1,
                Brand = "Porsche",
                Model = "911",
                Description = "Upptäck Peugeot 3008 och dess unika revolutionerande stil. Med Peugeot i-Cockpit® och innovativ teknik i framkant förstärks ditt välbefinnande, din säkerhet och din komfort. ",
                Image = "/images/cars/Porsche_911.webp"
            }
            );

        dbcontext.SaveChanges();

        return services;
    }
}

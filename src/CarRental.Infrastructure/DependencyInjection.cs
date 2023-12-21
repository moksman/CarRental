using CarRental.Application.Interfaces;
using CarRental.Application.UseCases.Car.Get;
using CarRental.Core.Model;
using CarRental.Infrastructure.Data;
using CarRental.Infrastructure.Data.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

     
        dbcontext.Cars.AddRange(
            new Car<int>
            {
                Brand = "Volvo",
                Model = "XC90",
                Description = "Genom att addera elkraft får du en laddhybrid som tar hänsyn till morgondagen, utan att kompromissa med körupplevelsen."
            },
            new Car<int>
            {
                Brand = "Renault",
                Model = "Clio",
                Description = "Easy Link 7” –multimediasystem med 7-tums högupplöst pekskärm – kompatibel med Android Auto™ och Apple CarPlay – sex högtalare, Bluetooth®, två USB-uttag, ett AUX-uttag Manuell luftkonditionering Aktiv panikbromsning med fotgängar- och cyklistavkänning (AEBS City + Inter Urbain) Filbytesvarnare och Filhållarassistans"
            },
            new Car<int>
            {
                Brand = "BMW",
                Model = "M4",
                Description = "Lyssna på det här: 550 hästkrafter, elektrisk xDrive, och 0-100 km/h på 3,9 sekunder. BMW i4 är helt enkelt elbilen för dig som älskar att köra. Här får du uppleva sportig prestanda i förstklassig komfort. Bakhjuls- eller fyrhjulsdrivet väljer du själv. Med 590 kilometers räckvidd och bagageutrymme som en halvkombi får du en flexibel kompanjon på långresan. Klara, färdiga, njut!"
            },
            new Car<int>
            {
                Brand = "Audi",
                Model = "Q4",
                Description = "Interiören i Audi Q4 e-tron präglas av innovativ teknik, sportighet och funktionalitet – som Audi virtual cockpit som ingår som standard."
            },
            new Car<int>
            {
                Brand = "Peugeot",
                Model = "3008",
                Description = "Upptäck Peugeot 3008 och dess unika revolutionerande stil. Med Peugeot i-Cockpit® och innovativ teknik i framkant förstärks ditt välbefinnande, din säkerhet och din komfort. "
            }
            );

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
            }
            );



        dbcontext.SaveChanges();

        return services;
    }
}

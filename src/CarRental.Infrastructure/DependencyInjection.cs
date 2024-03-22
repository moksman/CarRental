using CarRental.Application.Abstractions;
using CarRental.Application.UseCases.Car.Queries.Get;
using CarRental.Core.Domain;
using CarRental.Core.Enums;
using CarRental.Infrastructure.Data;
using CarRental.Infrastructure.Data.Abstractions;
using CarRental.Infrastructure.Data.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace CarRental.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigurePersistance(this IServiceCollection services, IConfiguration configuration) //where TId : class
    {
        //services.AddDbContext<AppDbContext>();

        //moved configuration to dbcontext class so that migration will run
        services.AddDbContext<AppDbContext>(options =>
        {
            //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            options.UseSqlite($"Data Source={System.IO.Path.Join(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData), "CarRental.db")}");

            //options.UseInMemoryDatabase(databaseName: "WeatherForecastDb");
        });

        services
            .AddScoped<IBaseRepository<Car, CarId>, BaseRepository<Car, CarId>>()
            .AddScoped<IBaseRepository<City, CityId>, BaseRepository<City, CityId>>()
            .AddScoped<IBaseRepository<User, UserId>, BaseRepository<User, UserId>>()
            .AddScoped<IListCarQueryService, ListCarQueryService>();

        return services;
    }

    public static IServiceCollection AddData(this IServiceCollection services)
    {
        var sp = services.BuildServiceProvider();

        var dbcontext = (AppDbContext)sp.GetService(typeof(AppDbContext));

        dbcontext.Database.EnsureDeleted();
        dbcontext.Database.EnsureCreated();        

        dbcontext.Cities.AddRange(
            City.Create(new (Guid.Parse("a454641b-de2d-4b92-b3c0-2ed7e56afa9c")), "Prague"),
            City.Create(new (Guid.NewGuid()), "Brno"),
            City.Create(new(Guid.NewGuid()), "Liberec"),
            City.Create(new(Guid.NewGuid()), "Pardubice"));

        dbcontext.SaveChanges();

        dbcontext.Cars.AddRange(
            Car.Create(
                new(Guid.Parse("2a959a26-1a1e-4dcd-a182-bfa8965a26bd")),
                dbcontext.Cities.ElementAt(0).Id,
                "Audi",
                "A3",
                "Easy Link 7” –multimediasystem med 7-tums högupplöst pekskärm – kompatibel med Android Auto™ och Apple",
                "/images/cars/audi_rs6.webp",
                4,
                100,
                VehiculeType.SPORT,
                TransmissionType.AUTOMATIC),
              Car.Create(
                new(Guid.NewGuid()),
                dbcontext.Cities.ElementAt(0).Id,
                "Audi",
                "RS6",
                "Easy Link 7” –multimediasystem med 7-tums högupplöst pekskärm – kompatibel med Android Auto™ och Apple CarPlay – sex högtalare, Bluetooth®, två USB-uttag, ett AUX-uttag Manuell luftkonditionering Aktiv panikbromsning med fotgängar- och cyklistavkänning (AEBS City + Inter Urbain) Filbytesvarnare och Filhållarassistans",
                "/images/cars/audi_rs6.webp",
                4,
                100,
                VehiculeType.SPORT,
                TransmissionType.AUTOMATIC),
              Car.Create(
                new(Guid.NewGuid()),
                dbcontext.Cities.ElementAt(0).Id,
                "Audi",
                "RS8",
                "Easy Link 7” –multimediasystem med 7-tums högupplöst pekskärm – kompatibel med Android Auto™ och Apple CarPlay – sex högtalare, Bluetooth®, två USB-uttag, ett AUX-uttag Manuell luftkonditionering Aktiv panikbromsning med fotgängar- och cyklistavkänning (AEBS City + Inter Urbain) Filbytesvarnare och Filhållarassistans",
                "/images/cars/audi_rs8.webp",
                4,
                100,
                VehiculeType.SPORT,
                TransmissionType.AUTOMATIC),
               Car.Create(
                new(Guid.NewGuid()),
                dbcontext.Cities.ElementAt(0).Id,
                "Audi",
                "RS6",
                "Lyssna på det här: 550 hästkrafter, elektrisk xDrive, och 0 - 100 km / h på 3, 9 sekunder.BMW i4 är helt enkelt elbilen för dig som älskar att köra.Här får du uppleva sportig prestanda i förstklassig komfort.Bakhjuls - eller fyrhjulsdrivet väljer du själv.",
                "/images/cars/audi_rs8.webp",
                4,
                120,
                VehiculeType.SPORT,
                TransmissionType.AUTOMATIC),
               Car.Create(
                new(Guid.NewGuid()),
                dbcontext.Cities.ElementAt(0).Id,
                "BENTLEY",
                "CONTINENTAL GT",
                "Genom att addera elkraft får du en laddhybrid som tar hänsyn till morgondagen, utan att kompromissa med körupplevelsen. Med 590 kilometers räckvidd och bagageutrymme som en halvkombi får du en flexibel kompanjon på långresan. Klara, färdiga, njut!",
                "/images/cars/BENTLEY_CONTINENTAL_GT.webp",
                2,
                170,
                VehiculeType.COUPE,
                TransmissionType.AUTOMATIC),
               Car.Create(
                new(Guid.NewGuid()),
                dbcontext.Cities.ElementAt(0).Id,
                "Lamborghini",
                "Urus",
                "Interiören i Audi Q4 e-tron präglas av innovativ teknik, sportighet och funktionalitet – som Audi virtual cockpit som ingår som standard. Med 590 kilometers räckvidd och bagageutrymme som en halvkombi får du en flexibel kompanjon på långresan. Klara, färdiga, njut!",
                "/images/cars/lambo_urus.webp",
                4,
                170,
                VehiculeType.SPORT,
                TransmissionType.AUTOMATIC),
               Car.Create(
                new(Guid.NewGuid()),
                dbcontext.Cities.ElementAt(1).Id,
                "Mercedes",
                "G63",
                "Upptäck Peugeot 3008 och dess unika revolutionerande stil. Med Peugeot i-Cockpit® och innovativ teknik i framkant förstärks ditt välbefinnande, din säkerhet och din komfort. ",
                "/images/cars/mercedes_g63.webp",
                4,
                170,
                VehiculeType.SPORT,
                TransmissionType.MANUAL),
               Car.Create(
                new(Guid.NewGuid()),
                dbcontext.Cities.ElementAt(1).Id,
                "Porsche",
                "911",
                "Upptäck Peugeot 3008 och dess unika revolutionerande stil. Med Peugeot i-Cockpit® och innovativ teknik i framkant förstärks ditt välbefinnande, din säkerhet och din komfort. ",
                "/images/cars/Porsche_911.webp",
                2,
                200,
                VehiculeType.SPORT,
                TransmissionType.MANUAL)
            );

        dbcontext.Users.AddRange(
                       User.Create(
                           new(Guid.NewGuid()), 
                           "bigben197602@gmail.com",
                           "password",
                           "Ben",
                           "Big",
                           "06 12 34 56 78",
                           null));

        dbcontext.SaveChanges();

        return services;
    }
}

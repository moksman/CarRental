using CarRental.Application.UseCases.Car.Queries.Get;
using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Data.Queries;

//Infrastructor services, high speed t-sql queris direct agains the db
internal class ListCarQueryService : IListCarQueryService
{
    private readonly AppDbContext _db;
    public ListCarQueryService(AppDbContext context)
    {
        _db = context;

    }


    public async Task<IList<CarDto>> ListAsync()
    {
        //var result = await _db.Cars.FromSqlRaw("SELECT * FROM Car")
        //    .Select(c => Car.Create(c.Id, c.CityId, c.Brand, c.Model, c.Description, c.Image, c.NoOfSeats, c.Price, c.Type, c.Transmission))
        //    .ToListAsync<Car>();

        return null;
    }
}

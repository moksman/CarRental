using CarRental.Application.UseCases.Car.Get;
using CarRental.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Data.Queries;

//Infrastructor services, high speed t-sql queris direct agains the db
internal class ListCarQueryService<TId> : IListCarQueryService<TId>
{
    private readonly AppDbContext<TId> _db;
    public ListCarQueryService(AppDbContext<TId> context)
    {
        _db = context;
    }

    public async Task<IList<Car<TId>>> ListAsync()
    {
        var result = await _db.Cars.FromSqlRaw("SELECT * FROM Car")
            .Select(c => new Car<TId> { Id = c.Id, Brand = c.Brand, Model = c.Model, Description = c.Description, Image = c.Image })
            .ToListAsync<Car<TId>>();

        return result;
    }
}

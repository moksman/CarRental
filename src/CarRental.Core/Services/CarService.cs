using CarRental.Core.Model;

namespace CarRental.Core.Services;

//Domain services, contains domain logic that doesnt belong to a specific domain entity
public class CarService<TId> : ICarService<TId>
{
    //private readonly IBaseRepository<Car<TId>, TId> _repository;

    //public CarService(IBaseRepository<Car<TId>, TId> repository)
    public CarService()
    {
    }


    //public async Task<WeatherForecast<TId>> Create(WeatherForecast<TId> forecast)
    //{
    //    return await Task.Run(() => forecast);
    //}

}

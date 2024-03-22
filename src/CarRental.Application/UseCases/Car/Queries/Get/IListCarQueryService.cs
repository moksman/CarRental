using CarRental.Application.UseCases.Dto;

namespace CarRental.Application.UseCases.Car.Queries.Get;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListCarQueryService
{
    Task<IList<CarDto>> ListAsync();
}


//public interface IListWeatherQueryService<TId>
//{
//    Task<IEnumerable<WeatherForecastDto>> ListAsync();
//}

using CarRental.Core.Model;

namespace CarRental.Application.UseCases.Car.Get;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListCarQueryService<TId>
{
    Task<IList<Car<TId>>> ListAsync();
}


//public interface IListWeatherQueryService<TId>
//{
//    Task<IEnumerable<WeatherForecastDto>> ListAsync();
//}

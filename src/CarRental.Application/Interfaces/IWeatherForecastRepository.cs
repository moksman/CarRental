using Core.Model;
using SharedKernel;

namespace Core.Interfaces;

//public interface IWeatherForecastRepo : IBaseRepository<Entity<EntityId> ,EntityId>
public interface IWeatherForecastRepository<TId> : IBaseRepository<WeatherForecast<TId>, TId>
{
}

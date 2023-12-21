using Core.Model;
using SharedKernel;

namespace Application.Interfaces;

//public interface IWeatherForecastRepo : IBaseRepository<Entity<EntityId> ,EntityId>
public interface IWeatherForecastRepository : IBaseRepository<WeatherForecast, EntityId>
{
}

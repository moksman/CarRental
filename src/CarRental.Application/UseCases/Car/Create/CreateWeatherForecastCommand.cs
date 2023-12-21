using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Weather.Command
{
    public class CreateWeatherForecastCommand<TId> : IRequest<WeatherForecast<TId>>
    {
        public WeatherForecast<TId> NewWeatherForecast { get; set; }
    }
}

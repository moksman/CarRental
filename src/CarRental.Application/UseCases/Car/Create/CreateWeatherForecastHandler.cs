using Core.Interfaces;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Weather.Command
{
    public class CreateWeatherForecastHandler<TId> : IRequestHandler<CreateGenericWeatherForecastCommand<TId>, WeatherForecast<TId>>
    {
        private readonly IWeatherForecastService<TId> _weatherForecastService;

        //public CreateWeatherForecastHandler(IWeatherForecastService weatherForecastService)
        public CreateWeatherForecastHandler()
        {
            //_weatherForecastService = weatherForecastService;
        }
        public async Task<WeatherForecast<TId>> Handle(CreateGenericWeatherForecastCommand<TId> request, CancellationToken cancellationToken)
        {
            return await _weatherForecastService.Create(request.NewWeatherForecast);
        }
    }
}

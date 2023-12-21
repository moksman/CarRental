using CarRental.Application.Interfaces;
using CarRental.Core.Model;
using MediatR;

namespace CarRental.Application.UseCases.Car.Get
{

    public class GetCarByCityQueryHandler<TId> : IRequestHandler<GetCarByCityQuery<TId>, IEnumerable<Car<TId>>>
    {
        private readonly IListCarQueryService<TId> _carService;
        private readonly IBaseRepository<Car<TId>, TId> _carRepository;


        public GetCarByCityQueryHandler(IListCarQueryService<TId> weatherService, IBaseRepository<Car<TId>, TId> weatherForecastRepository)
        {
            _carService = weatherService;
            _carRepository = weatherForecastRepository;
        }
        public async Task<IEnumerable<Car<TId>>> Handle(GetCarByCityQuery<TId> request, CancellationToken cancellationToken)
        {
            //return await _weatherService.ListAsync();
            return await _carRepository.GetAllAsync();
        }

    }
}

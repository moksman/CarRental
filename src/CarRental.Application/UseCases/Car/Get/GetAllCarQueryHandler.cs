using CarRental.Application.Interfaces;
using CarRental.Core.Model;
using MediatR;

namespace CarRental.Application.UseCases.Car.Get
{

    public class GetAllCarQueryHandler<TId> : IRequestHandler<GetAllCarQuery<TId>, IEnumerable<Car<TId>>>
    {
        private readonly IListCarQueryService<TId> _carService;
        private readonly IBaseRepository<Car<TId>, TId> _carRepository;


        public GetAllCarQueryHandler(IListCarQueryService<TId> weatherService, IBaseRepository<Car<TId>, TId> weatherForecastRepository)
        {

            _carService = weatherService;
            _carRepository = weatherForecastRepository;
        }
        public async Task<IEnumerable<Car<TId>>> Handle(GetAllCarQuery<TId> request, CancellationToken cancellationToken)
        {
            //return await _weatherService.ListAsync();
            return await _carRepository.GetAllAsync();
        }

    }
}

using CarRental.Application.Interfaces;
using CarRental.Core.Model;
using CarRental.Core.Services;
using MediatR;

namespace CarRental.Application.UseCases.Car.Create;

public class CreateCarHandler<TId> : IRequestHandler<CreateCarCommand<TId>, Car<TId>>
{
    private readonly IBaseRepository<Car<TId>, TId> _repository;
    private readonly ICarService<TId> _carService;

    //public CreateWeatherForecastHandler(IWeatherForecastService weatherForecastService)
    public CreateCarHandler(IBaseRepository<Car<TId>, TId> repository, ICarService<TId> carService)
    {
        repository = _repository ?? throw new ArgumentNullException(nameof(repository));
        carService = _carService;
    }
    public async Task<Car<TId>> Handle(CreateCarCommand<TId> request, CancellationToken cancellationToken)
    {
        return await _repository.AddAsync(request.NewCar);
    }
}

using CarRental.Application.Abstractions;
using CarRental.Application.Configuration;
using CarRental.Application.UseCases.Dto;
using MediatR;

namespace CarRental.Application.UseCases.Car.Commands.Create;

public record CreateCarHandler : IRequestHandler<CreateCarCommand, CarDto>
{
    //private readonly IGenericService<CarDto> _carService;
    private readonly IBaseRepository<Core.Domain.Car, Guid> _repository;
    CarMapper _mapper;

    public CreateCarHandler(IBaseRepository<Core.Domain.Car, Guid> repository, CarMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {

        var car = Core.Domain.Car.Create(
            request.NewCar.Id, 
            request.NewCar.CityId, 
            request.NewCar.Brand, 
            request.NewCar.Model, 
            request.NewCar.Description, 
            request.NewCar.Image, 
            request.NewCar.NoOfSeats, 
            request.NewCar.Price, 
            request.NewCar.Type, 
            request.NewCar.Transmission);


        var item = _repository.Add(car);

        await _repository.SaveChanges();

        return _mapper.CarToCarDto(item);
    }


}

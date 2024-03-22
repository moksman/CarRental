using CarRental.Application.Abstractions;
using CarRental.Application.UseCases.Dto;
using MediatR;

namespace CarRental.Application.UseCases.Car.Commands.Create;

public record CreateCarHandler : IRequestHandler<CreateCarCommand, CarDto>
{
    //private readonly IGenericService<CarDto> _carService;
    private readonly IBaseRepository<CarDto, Guid> _repository;

    public CreateCarHandler(IBaseRepository<CarDto, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<CarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var item = _repository.Add(request.NewCar);

        await _repository.SaveChanges();

        return item;
    }


}

using CarRental.Application.UseCases.Dto;
using MediatR;

namespace CarRental.Application.UseCases.Car.Commands.Create
{
    public record CreateCarCommand(CarDto NewCar) : IRequest<CarDto>;

}

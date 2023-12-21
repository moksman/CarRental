using CarRental.Core.Model;
using MediatR;

namespace CarRental.Application.UseCases.Car.Create
{
    public class CreateCarCommand<TId> : IRequest<Car<TId>>
    {
        public Car<TId> NewCar{ get; set; }
    }
}

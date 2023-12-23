using CarRental.Core.Model;
using MediatR;

namespace CarRental.Application.UseCases.Car.Get;

public class GetAllCarQuery<TId> : IRequest<IEnumerable<Car<TId>>>
{


}
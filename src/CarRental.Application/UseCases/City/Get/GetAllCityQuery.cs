using CarRental.Core.Model;
using MediatR;

namespace CarRental.Application.UseCases.City.Get;

public class GetAllCityQuery<TId> : IRequest<IEnumerable<City<TId>>>
{


}
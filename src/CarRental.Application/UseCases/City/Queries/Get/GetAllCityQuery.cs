using CarRental.Application.UseCases.Dto;
using MediatR;

namespace CarRental.Application.UseCases.City.Queries.Get;

public class GetAllCityQuery : IRequest<IEnumerable<CityDto>>
{


}
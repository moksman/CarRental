using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using MediatR;

namespace CarRental.Application.UseCases.Car.Queries.Get;

public class GetCarByCityQuery : IRequest<IEnumerable<CarDto>>
{
    public CityId CityId { get; set; }

    public GetCarByCityQuery(CityId cityId)
    {
        CityId = cityId;
    }

}
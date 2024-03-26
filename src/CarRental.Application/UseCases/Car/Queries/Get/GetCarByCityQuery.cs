using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using MediatR;

namespace CarRental.Application.UseCases.Car.Queries.Get;

public class GetCarByCityQuery : IRequest<IEnumerable<CarDto>>
{
    public Guid Guid { get; set; }

    public GetCarByCityQuery(Guid cityId)
    {
        Guid = cityId;
    }

}
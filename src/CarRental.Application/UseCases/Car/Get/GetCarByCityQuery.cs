using CarRental.Core.Model;
using MediatR;

namespace CarRental.Application.UseCases.Car.Get;

public class GetCarByCityQuery<TId> : IRequest<IEnumerable<Car<TId>>>
{
    public int CityId { get; set; }

    public GetCarByCityQuery(int cityId)
    {
        CityId = cityId;
    }

}
using CarRental.Application.Abstractions;
using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using CarRental.Core.Enums;
using MediatR;

namespace CarRental.Application.UseCases.Car.Queries.Get;

public class GetCarsQuery : IRequest<IEnumerable<CarDto>>
{
    public VehiculeType VehiculeType { get; set; }
    public TransmissionType TransmissionType { get; set; }
    public int Passangers { get; set; }
    public int[] CountryIds { get; set; }


}

// Path: src/CarRental.Application/UseCases/Car/Get/GetCarsQueryHandler.cs
//using CarRental.Core.Model;
//using MediatR;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CarRental.Application.UseCases.Car.Get;
public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, IEnumerable<CarDto>>
{
    private readonly IBaseRepository<Core.Domain.Car, CarId> _repository;

    public GetCarsQueryHandler(IBaseRepository<Core.Domain.Car, CarId> repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<CarDto>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
    {
        return null;
        //return await _repository.GetCars(
        //    request.VehiculeType, 
        //    request.TransmissionType, 
        //    request.Passangers, 
        //    request.CountryIds);
    }
}
// Path: src/CarRental.Application/UseCases/Car/Get/GetCarsQueryDtoProfile
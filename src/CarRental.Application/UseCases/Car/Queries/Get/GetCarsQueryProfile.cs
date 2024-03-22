using AutoMapper;

namespace CarRental.Application.UseCases.Car.Queries.Get;

// Path: src/CarRental.Application/UseCases/Car/Get/GetCarsQueryProfile.cs
//using AutoMapper;
//using CarRental.Core.Model;
//namespace CarRental.Application.UseCases.Car.Get;
public class GetCarsQueryProfile : Profile
{
    public GetCarsQueryProfile()
    {
        CreateMap<GetCarsQuery, GetCarsQueryDto>();
    }
}
// Path: src/CarRental.Application/UseCases/Car/Get/GetCarsQueryDtoProfile
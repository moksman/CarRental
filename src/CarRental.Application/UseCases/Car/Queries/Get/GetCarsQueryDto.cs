using CarRental.Core.Enums;

namespace CarRental.Application.UseCases.Car.Queries.Get;

// Path: src/CarRental.Application/UseCases/Car/Get/GetCarsQueryDto.cs
//using CarRental.Core.Enums;
//namespace CarRental.Application.UseCases.Car.Get;
public record GetCarsQueryDto(VehiculeType VehiculeType, TransmissionType TransmissionType, int Passangers, int[] CountryIds);
// Path: src/CarRental.Application/UseCases/Car/Get/GetCarsQueryDtoProfile
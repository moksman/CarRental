using CarRental.Core.Enums;

namespace CarRental.Application.UseCases.Dto;


public record CarDto(Guid Id, Guid CityId, string Brand, string Model, string Description, string? Image, int NoOfSeats, decimal? Price, VehiculeType Type, TransmissionType Transmission);



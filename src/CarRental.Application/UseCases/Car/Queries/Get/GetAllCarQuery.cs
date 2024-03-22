using CarRental.Application.UseCases.Dto;
using MediatR;


public record GetAllCarQuery : IRequest<IEnumerable<CarDto>>;
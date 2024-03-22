using MediatR;

namespace CarRental.Application.UseCases.User.Commands.Login;

public record LoginCommand(string Email) : IRequest<string>;

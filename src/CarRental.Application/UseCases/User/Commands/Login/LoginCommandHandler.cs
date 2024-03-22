using CarRental.Application.Abstractions;
using CarRental.Core.Domain;
using MediatR;

namespace CarRental.Application.UseCases.User.Commands.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IBaseRepository<Core.Domain.User, UserId> _userRepository;

    public LoginCommandHandler(IBaseRepository<Core.Domain.User, UserId> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //Get user
        //User user = await _userRepository.Get(x => x.Email == request.Email);


        //Generate token

        //return token

        return await Task.FromResult("Login successful");
    }
}

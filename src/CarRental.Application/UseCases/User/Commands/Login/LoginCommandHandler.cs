using CarRental.Application.Abstractions;
using CarRental.Core.Domain;
using MediatR;

namespace CarRental.Application.UseCases.User.Commands.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IBaseRepository<Core.Domain.User, Guid> _userRepository;

    public LoginCommandHandler(IBaseRepository<Core.Domain.User, Guid> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(
        LoginCommand request, 
        CancellationToken cancellationToken)
    {
        //Get user
        Core.Domain.User user = await _userRepository.Get(x => x.Email == request.Email);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        
        //Generate token

        //return token

        return await Task.FromResult("Login successful");
    }
}

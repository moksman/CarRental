using Moq;
using CarRental.Application.UseCases.User.Commands.Login;
using CarRental.Core.Domain;
using CarRental.Application.Abstractions;

namespace CarRental.UnitTest;

public class LoginCommandHandlerTests
{
    [Theory]
    [InlineData("5605ed93-e7d3-47fb-9a0d-2832b0ab267f", "test@test.com", "###", "Ben", "Jerry", "06-123345", null)]
    [InlineData("5605ed93-e7d3-47fb-9a0d-2832b0ab267f", "UserDoesntExist@test.com", "###", "Ben", "Jerry", "06-123345", null)]
    public async void Handle_ValidRequest_ReturnsExpectedResult(string UserId, string Email, string Password, string Firstname, string Lastname, string PhoneNumber, string imageUrl)
    {
        // Arrange
        Mock<IBaseRepository<User, Guid>> mockRepository = new ();
        var user = User.Create(Guid.NewGuid(), "test@test.com", "###", "Ben", "Jerry", "06-123345", null);
        mockRepository.Setup(repo => repo.Get(It.IsAny<Func<User, bool>>())).ReturnsAsync(user);

        LoginCommandHandler handler = new (mockRepository.Object);
        LoginCommand request = new ("test@test.com");

        if(request is null)



        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.Equal("Login successful", result);
    }
}

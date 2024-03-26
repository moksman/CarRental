using CarRental.Core.Abstractions;
using CarRental.Core.DomainEvents;

namespace CarRental.Core.Domain;

public class User : Entity<Guid>
{
    private User(Guid id, string email, string password, string firstName, string lastName, string phoneNumber, string? image) : base(id)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Image = image;
    }

    public string Email { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string? Image { get; private set; }

    public static User Create(Guid id, string email, string password, string firstName, string lastName, string phoneNumber, string? image)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email, nameof(email));
        ArgumentException.ThrowIfNullOrWhiteSpace(password, nameof(password));
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));
        ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber, nameof(phoneNumber));

        User user = new(id, email, password, firstName, lastName, phoneNumber, image);

        user.Raise(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}

using CarRental.Core.Abstractions;
using CarRental.Core.Domain;

namespace CarRental.Core.DomainEvents;

internal sealed record UserCreatedDomainEvent(UserId id) : IDomainEvent
{
}
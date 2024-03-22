using CarRental.Core.Abstractions;

namespace CarRental.Core.DomainEvents;


public sealed record ReservationAcceptedDomainEvent(Guid CarId, Guid CustomerId) : IDomainEvent
{
}
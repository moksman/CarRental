using CarRental.Core.Abstractions;

namespace CarRental.Core.DomainEvents;

public sealed record CarCreatedDomainEvent(Core.Domain.CarId CarId) : IDomainEvent;

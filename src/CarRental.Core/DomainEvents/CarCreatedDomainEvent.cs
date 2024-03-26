using CarRental.Core.Abstractions;

namespace CarRental.Core.DomainEvents;

public sealed record CarCreatedDomainEvent(Guid Guid) : IDomainEvent;

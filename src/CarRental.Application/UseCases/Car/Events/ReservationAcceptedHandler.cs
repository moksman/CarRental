using CarRental.Application.Abstractions;
using CarRental.Core.Domain;
using CarRental.Core.DomainEvents;
using MediatR;

namespace CarRental.Application.UseCases.Car.Events
{
    internal sealed class ReservationAcceptedHandler : INotificationHandler<ReservationAcceptedDomainEvent>
    {
        private readonly IBaseRepository<Core.Domain.Car, Guid> _repository;

        public ReservationAcceptedHandler(IBaseRepository<Core.Domain.Car, Guid> repository)
        {
            _repository = repository;
        }

        public Task Handle(ReservationAcceptedDomainEvent notification, CancellationToken cancellationToken)
        {
            Guid Guid = notification.Guid;
            Guid customerId = notification.CustomerId;

            //Do your logic here


            throw new NotImplementedException();
        }
    }
}

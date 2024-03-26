using CarRental.Core.Abstractions;
using CarRental.Core.DomainEvents;
using CarRental.Core.Enums;

namespace CarRental.Core.Domain;

public sealed class Car : Entity<Guid>
{
  

    private Car(Guid id, Guid cityId, string brand, string model, string description, string? image, int noOfSeats, decimal? price, VehiculeType type, TransmissionType transmission) : base(id)
    {
        CityId = cityId;
        Brand = brand;
        Model = model;
        Description = description;
        Image = image;
        NoOfSeats = noOfSeats;
        Price = price;
        Type = type;
        Transmission = transmission;
    }

    public Guid CityId { get; private set; }

    //Normally avoid using primitive types in domain model (use concrete types), but for simplicity I use string.
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Description { get; private set; }
    public string? Image { get; private set; }

    public int NoOfSeats { get; private set; }

    public decimal? Price { get; private set; }

    public VehiculeType Type { get; private set; }

    public TransmissionType Transmission { get; private set; }

    public static Car Create(Guid id, Guid cityId, string brand, string model, string description, string? image, int noOfSeats, decimal? price, VehiculeType type, TransmissionType transmission)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brand, nameof(brand));
        ArgumentException.ThrowIfNullOrWhiteSpace(model, nameof(model));
        ArgumentException.ThrowIfNullOrWhiteSpace(description, nameof(description));

        Car car = new(id, cityId, brand, model, description, image, noOfSeats, price, type, transmission);

        car.Raise(new CarCreatedDomainEvent(id));

        return car;
    }
}

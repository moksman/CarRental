
namespace CarRental.Core.Model;

public record Car<TId> : Entity<TId>
{
    public TId CityId { get; set; }
    public string Brand {  get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }

    public decimal? Price { get; set; }

    public Vehicule Type { get; set; }

    public Transmission Transmission { get; set; }
}


public enum Vehicule
{
    //TODO: localize https://github.com/died/.NET-Core-Localization-and-Enum
    SPORT,
    COUPE
}

public enum Transmission
{ 
    AUTOMATIC,
    MANUAL
}

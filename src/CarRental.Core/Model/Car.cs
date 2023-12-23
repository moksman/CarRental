
namespace CarRental.Core.Model;

public record Car<TId> : Entity<TId>
{
    public TId CityId { get; set; }
    public string Brand {  get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
}

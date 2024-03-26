using System.ComponentModel.DataAnnotations.Schema;
using CarRental.Core.Abstractions;

namespace CarRental.Core.Domain;

public sealed class City : Entity<Guid>
{
    private City(Guid id, string name) :  base(id)
    {
        Name = name;
    }

    //Normally avoid using primitive types in domain model (use concrete types), but for simplicity I use string.
    public string Name { get; private set; }

    public static City Create(Guid id, string name)
    {
        City city = new(id, name);

        return city;
    }
  

    [NotMapped]
    public bool IsSelected { get; set; } = false;
    
}

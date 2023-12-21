using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Model;

//public abstract class Entity<TEntityId>
//{
//    //public TEntityId Id { get; init; }
//    public TEntityId Id { get; set; }

//    public Entity()
//    {

//    }
//    public Entity(TEntityId id)
//    {
//        Id = id;
//    }

//}

public record Entity<TId>
{
    public TId Id { get; set; }

    public Entity()
    {

    }
    public Entity(TId id)
    {
        Id = id;
    }
}

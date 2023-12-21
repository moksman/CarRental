using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Model
{
    public record City<TId> : Entity<TId>
    {
        public string Name { get; set; }
    }
}

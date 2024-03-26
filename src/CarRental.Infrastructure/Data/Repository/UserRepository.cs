using CarRental.Core.Domain;
using CarRental.Infrastructure.Data.Abstractions;

namespace CarRental.Infrastructure.Data.Repository;

internal class UserRepository : BaseRepository<User, Guid>
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}

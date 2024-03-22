using CarRental.Core.Domain;
using CarRental.Infrastructure.Data.Abstractions;

namespace CarRental.Infrastructure.Data.Repository;

internal class UserRepository : BaseRepository<User, UserId>
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}

using CarRental.Application.Interfaces;
using CarRental.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Data;

//public abstract class Repository<TEntity, TId> : IBaseRepository<TEntity, TId>
internal class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
    where TEntity : Entity<TId>
    //where TId : class
{
    private readonly AppDbContext<TId> _db;

    public BaseRepository(AppDbContext<TId> context)
    {
        _db = context;
    }

    public async Task<TEntity> GetByIdAsync(TId id) => await _db.Set<TEntity>().SingleOrDefaultAsync(x => x.Id.Equals(id));

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _db.Set<TEntity>().Add(entity);

        return entity;
    }

    public void Update(TEntity entity) { }

    public void Delete(TEntity entity) { }

    public async Task<List<TEntity>> GetAllAsync() => await _db.Set<TEntity>().ToListAsync();

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _db.SaveChangesAsync(cancellationToken);
    }


}

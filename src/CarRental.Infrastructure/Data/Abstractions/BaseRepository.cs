using CarRental.Application.Abstractions;
using CarRental.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Data.Abstractions;

internal class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : class
{
    private readonly AppDbContext _db;

    //add unit of work pattern to class BaseRepository

    //private readonly IUnitOfWork _unitOfWork;
    //write base repository with unit of work

    public BaseRepository(AppDbContext context)
    {
        _db = context;
    }


    //public async Task<TEntity> GetById(Guid id) => await _db.Set<TEntity>().SingleOrDefaultAsync(x => x.Id.Equals(id));

    public TEntity Add(TEntity entity)
    {
        _db.Set<TEntity>().Add(entity);

        return entity;
    }

    public void Update(TEntity entity) { }

    public void Delete(TEntity entity) { }

    //public async Task<List<TEntity>> GetAllAsync() => await _db.Set<TEntity>().ToListAsync();
    public async Task<List<TEntity>> GetAll()
    {
        //await Task.Delay(2000);

        return await _db.Set<TEntity>().ToListAsync();
    }

    public async Task<int> SaveChanges(CancellationToken cancellationToken)
    {
        return await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity> Get(Func<TEntity, bool> query)
    {
        var result = _db.Set<TEntity>().Where(query);
        
        return await Task.FromResult(result as TEntity);
    }

    public Task<TEntity> GetById(TId id)
    {
        throw new NotImplementedException();
    }
}

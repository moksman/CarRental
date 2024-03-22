using CarRental.Core.Domain;

namespace CarRental.Application.Abstractions;

public interface IBaseRepository<TEntity, TEntityId>
{
    public Task<TEntity> GetById(TEntityId id);

    public Task<List<TEntity>> GetAll();

    public TEntity Add(TEntity entity);
    
    public Task<int> SaveChanges(CancellationToken cancellationToken = default);
    Task<TEntity> Get(Func<TEntity, bool> value);
}

using CarRental.Core.Abstractions;
using CarRental.Core.Domain;

public interface IGenericService<TEntity, TId> //where T : class
{
    
    Task<IEnumerable<TEntity>> GetAll();
    TEntity Add(TEntity car);

    Task<int> SaveChanges();
}
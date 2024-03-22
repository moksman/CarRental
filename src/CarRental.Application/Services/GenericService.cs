using CarRental.Application.Abstractions;
using CarRental.Core.Abstractions;

namespace CarRental.Application.Services;

public class GenericService<TEntity, TId> : IGenericService<TEntity, TId> where TEntity : Entity<TId>
{

    //private readonly IService<TEntity> _service;
    //private readonly IEventDispatcher _eventDispatcher;
    private readonly IBaseRepository<TEntity, TId> _repository;

    //public CarService(IBaseRepository<Car> carRepository, IEventDispatcher eventDispatcher)
    public GenericService(IBaseRepository<TEntity, TId> repository)
    {
        _repository = repository;
        //_eventDispatcher = eventDispatcher;
    }

  

    public TEntity Add(TEntity item)
    {
        return _repository.Add(item);

        //foreach (var domainEvent in car.DomainEvents)
        //{
        //    _eventDispatcher.Dispatch(domainEvent);
        //}
    }

    public Task<IEnumerable<TEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<int> SaveChanges()
    {
        return await _repository.SaveChanges();
    }

    async Task<IEnumerable<TEntity>> IGenericService<TEntity, TId>.GetAll()
    {
        return await _repository.GetAll();
    }
}

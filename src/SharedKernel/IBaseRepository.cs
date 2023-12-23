namespace SharedKernel;

public interface IBaseRepository<Entity, TId>
{
    public Task<Entity> GetByIdAsync(TId id);

    public Task<List<Entity>> GetAllAsync();

    public Task<Entity> AddAsync(Entity entity);

}
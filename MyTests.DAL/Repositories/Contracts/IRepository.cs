using Ardalis.Specification;

namespace MyTests.DAL.Repositories.Contracts;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<List<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);

    //specification pattern with Ardalis.Specification lib
    Task<List<TEntity>> ListAsync(Specification<TEntity> spec);
    Task<TEntity?> FirstOrDefaultAsync(Specification<TEntity> spec);
}

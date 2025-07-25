using Microsoft.EntityFrameworkCore;
using MyTests.Domain.Contracts;

namespace MyTests.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(MyTestsContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
    public virtual async Task<List<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
    public virtual async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);
    public virtual void Update(TEntity entity) => _dbSet.Update(entity);
    public virtual void Remove(TEntity entity) => _dbSet.Remove(entity);
}

using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTests.DAL.Repositories.Contracts;

namespace MyTests.DAL.Repositories;


public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    private readonly SpecificationEvaluator _specEvaluator;

    public Repository(MyTestsContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
        _specEvaluator = SpecificationEvaluator.Default;
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        => await _dbSet.FindAsync(id);

    public virtual async Task<List<TEntity>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public virtual async Task AddAsync(TEntity entity)
        => await _dbSet.AddAsync(entity);

    public virtual void Update(TEntity entity)
        => _dbSet.Update(entity);

    public virtual void Remove(TEntity entity)
        => _dbSet.Remove(entity);

    public virtual async Task<List<TEntity>> ListAsync(Specification<TEntity> spec)
    {
        var query = _specEvaluator.GetQuery(_dbSet.AsQueryable(), spec);
        return await query.ToListAsync();
    }

    public virtual async Task<TEntity?> FirstOrDefaultAsync(Specification<TEntity> spec)
    {
        var query = _specEvaluator.GetQuery(_dbSet.AsQueryable(), spec);
        return await query.FirstOrDefaultAsync();
    }
}
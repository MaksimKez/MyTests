using Microsoft.EntityFrameworkCore;
using MyTests.Domain.Contracts;
using MyTests.Domain.Entities;

namespace MyTests.DAL.Repositories;

public class ProductRepository : Repository<ProductEntity>, IProductRepository
{
    public ProductRepository(MyTestsContext context) : base(context)
    { }

    public async Task<List<ProductEntity>> GetAllAsync(int take, int skip)
        => await _dbSet.Take(take).Skip(skip).ToListAsync();
}
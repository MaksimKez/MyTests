using MyTests.DAL.Entities;
using MyTests.DAL.Repositories;
using MyTests.DAL.Repositories.Contracts;

namespace MyTests.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyTestsContext _context;

    public IProductRepository Products { get; }
    public IRepository<RefreshTokenEntity> RefreshTokens { get; }
    public IUserRepository Users { get; }

    public UnitOfWork(MyTestsContext context)
    {
        _context = context;
        Products = new ProductRepository(_context);
        RefreshTokens = new Repository<RefreshTokenEntity>(_context);
        Users = new UserRepository(_context);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}

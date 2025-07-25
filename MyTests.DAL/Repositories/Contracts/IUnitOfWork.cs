using MyTests.DAL.Entities;

namespace MyTests.DAL.Repositories.Contracts;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IRepository<RefreshTokenEntity> RefreshTokens { get; }
    IUserRepository Users { get; }

    Task<int> SaveChangesAsync();
}

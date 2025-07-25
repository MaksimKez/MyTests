using MyTests.Domain.Entities;

namespace MyTests.Domain.Contracts;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IRepository<RefreshTokenEntity> RefreshTokens { get; }
    IUserRepository Users { get; }

    Task<int> SaveChangesAsync();
}

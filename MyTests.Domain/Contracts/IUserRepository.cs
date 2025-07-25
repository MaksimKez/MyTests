using MyTests.Domain.Entities;

namespace MyTests.Domain.Contracts;

public interface IUserRepository : IRepository<UserEntity>
{
    Task<UserEntity?> GetByEmailAsync(string email);
}

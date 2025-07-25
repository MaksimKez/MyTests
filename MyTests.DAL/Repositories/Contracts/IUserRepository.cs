using MyTests.DAL.Entities;

namespace MyTests.DAL.Repositories.Contracts;

public interface IUserRepository : IRepository<UserEntity>
{
    Task<UserEntity?> GetByEmailAsync(string email);
}

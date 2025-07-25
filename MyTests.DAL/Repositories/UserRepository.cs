using Microsoft.EntityFrameworkCore;
using MyTests.Domain.Contracts;
using MyTests.Domain.Entities;

namespace MyTests.DAL.Repositories;

public class UserRepository : Repository<UserEntity>, IUserRepository
{
    public UserRepository(MyTestsContext context) : base(context) { }

    public async Task<UserEntity?> GetByEmailAsync(string email)
    {
        //left join'll be generated
        return await _dbSet.Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}

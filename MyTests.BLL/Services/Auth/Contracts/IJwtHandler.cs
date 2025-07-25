using MyTests.BLL.Models;

namespace MyTests.BLL.Services.Auth.Contracts;

public interface IJwtHandler
{
    string GenerateAccessToken(User user);
    RefreshToken GenerateRefreshToken(User user);
}
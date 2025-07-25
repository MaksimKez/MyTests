using MyTests.BLL.Models;
using MyTests.BLL.Models.AuthRelated;

namespace MyTests.BLL.Services.Auth.Contracts;

public interface IJwtHandler
{
    string GenerateAccessToken(User user);
    RefreshToken GenerateRefreshToken(User user);
}
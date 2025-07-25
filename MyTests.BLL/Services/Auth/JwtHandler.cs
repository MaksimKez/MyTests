using MyTests.BLL.Models;
using MyTests.BLL.Services.Auth.Contracts;

namespace MyTests.BLL.Services.Auth;

public class JwtHandler : IJwtHandler
{
    private readonly JwtOptions _jwtOptions;
    public JwtHandler(JwtOptions jwtOptions)
    {
        _jwtOptions = jwtOptions;
    }
    
    public string GenerateAccessToken(User user)
    {
        throw new NotImplementedException();
    }

    public string GenerateRefreshToken(User user)
    {
        throw new NotImplementedException();
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyTests.BLL.Models;
using MyTests.BLL.Models.AuthRelated;
using MyTests.BLL.Services.Auth.Contracts;

namespace MyTests.BLL.Services.Auth;

public class JwtHandler : IJwtHandler
{
    private readonly JwtOptions _jwtOptions;
    private readonly SymmetricSecurityKey _securityKey;

    public JwtHandler(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
        _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
    }

    public string GenerateAccessToken(User user)
    {
        var claims = GenerateClaims(user);
        var expires = DateTime.UtcNow.AddMinutes(_jwtOptions.AccessTokenExpiresMinutes);

        return GenerateToken(claims, expires);
    }

    public RefreshToken GenerateRefreshToken(User user)
    {
        var id = Guid.NewGuid();
        var claims = GenerateClaims(user, id);
        var expires = DateTime.UtcNow.AddHours(_jwtOptions.RefreshTokenExpiresHours);

        var token = GenerateToken(claims, expires);

        return new RefreshToken
        {
            Id = id,
            Token = token,
            UserId = user.Id
        };
    }

    private Claim[] GenerateClaims(User user, Guid? tokenId = null)
    {
        return
        [
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, tokenId?.ToString() ?? Guid.NewGuid().ToString()),
            new Claim("email_verified", user.IsVerified.ToString().ToLower()),
            new Claim(JwtRegisteredClaimNames.Iat,
                new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),
                ClaimValueTypes.Integer64)
        ];
    }

    private string GenerateToken(IEnumerable<Claim> claims, DateTime expires)
    {
        var credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

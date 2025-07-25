namespace MyTests.BLL.Models.AuthRelated;

public class JwtOptions
{
    public string SecretKey { get; set; }
    public int AccessTokenExpiresMinutes { get; set; }
    public int RefreshTokenExpiresHours { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}
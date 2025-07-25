namespace MyTests.BLL.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsVerified { get; set; }

    public ICollection<RefreshToken> RefreshTokens { get; set; }
}
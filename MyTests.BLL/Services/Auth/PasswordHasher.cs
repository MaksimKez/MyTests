using MyTests.BLL.Services.Auth.Contracts;

namespace MyTests.BLL.Services.Auth;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);
    
    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        => BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
}
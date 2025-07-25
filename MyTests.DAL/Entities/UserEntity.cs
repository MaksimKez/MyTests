namespace MyTests.DAL.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public bool IsVerified { get; set; } = false;
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; }

    public ICollection<RefreshTokenEntity> RefreshTokens { get; set; }
}
namespace MyTests.Domain.Entities;

public class RefreshTokenEntity
{
    public int Id { get; set; }
    public string Token { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }

    public int UserId { get; set; }
    public UserEntity User { get; set; }
}
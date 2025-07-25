using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MyTests.Domain.Entities;

namespace MyTests.DAL;

public class MyTestsContext : DbContext 
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    
    public MyTestsContext(DbContextOptions<MyTestsContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
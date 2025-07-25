using MyTests.Domain.Entities;

namespace MyTests.DAL.Extentions;

public static class ProductSeed
{
    public static void EnsureSeedData(this MyTestsContext db)
    {
        if (db.Products.Any())
            return;

        var products = new List<ProductEntity>
        {
            new() { Id = Guid.NewGuid(), Title = "Apple iPhone 15", ImageUrl = "https://example.com/iphone15.jpg", Price = 99900 },
            new() { Id = Guid.NewGuid(), Title = "Samsung Galaxy S24", ImageUrl = "https://example.com/galaxyS24.jpg", Price = 89900 },
            new() { Id = Guid.NewGuid(), Title = "Google Pixel 8", ImageUrl = "https://example.com/pixel8.jpg", Price = 79900 },
            new() { Id = Guid.NewGuid(), Title = "OnePlus 12", ImageUrl = "https://example.com/oneplus12.jpg", Price = 74900 },
            new() { Id = Guid.NewGuid(), Title = "Sony WH-1000XM5", ImageUrl = "https://example.com/sony-xm5.jpg", Price = 34900 },
            new() { Id = Guid.NewGuid(), Title = "MacBook Pro 14", ImageUrl = "https://example.com/macbook14.jpg", Price = 199900 },
            new() { Id = Guid.NewGuid(), Title = "Dell XPS 13", ImageUrl = "https://example.com/dellxps13.jpg", Price = 149900 },
            new() { Id = Guid.NewGuid(), Title = "iPad Air 2024", ImageUrl = "https://example.com/ipadair.jpg", Price = 59900 },
            new() { Id = Guid.NewGuid(), Title = "Amazon Kindle Paperwhite", ImageUrl = "https://example.com/kindle.jpg", Price = 12900 },
            new() { Id = Guid.NewGuid(), Title = "Logitech MX Master 3S", ImageUrl = "https://example.com/mxmaster.jpg", Price = 9900 }
        };

        db.Products.AddRange(products);
        db.SaveChanges();
    }
}

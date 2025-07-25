namespace MyTests.DAL.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public int Price { get; set; }
}
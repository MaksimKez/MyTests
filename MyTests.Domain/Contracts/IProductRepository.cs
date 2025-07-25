using MyTests.Domain.Entities;

namespace MyTests.Domain.Contracts;

public interface IProductRepository 
{
    Task<List<ProductEntity>> GetAllAsync(int take, int skip);
}
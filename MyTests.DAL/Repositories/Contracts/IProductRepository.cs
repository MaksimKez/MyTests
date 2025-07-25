using MyTests.DAL.Entities;

namespace MyTests.DAL.Repositories.Contracts;

public interface IProductRepository 
{
    Task<List<ProductEntity>> GetAllAsync(int take, int skip);
}
using MediatR;
using MyTests.BLL.Models;

namespace MyTests.BLL.Auth.Queries.GetProduct;

public record class GetProductsQuery(GetProductFilters Filters) : IRequest<ICollection<Product>>{}
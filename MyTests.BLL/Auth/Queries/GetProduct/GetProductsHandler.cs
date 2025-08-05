using AutoMapper;
using MyTests.BLL.Models;
using MyTests.DAL.Entities;
using MyTests.DAL.Repositories.Contracts;
using MyTests.DAL.Specifications;

namespace MyTests.BLL.Auth.Queries.GetProduct;

using MediatR;

public class GetProductsHandler(IRepository<ProductEntity> repository, IMapper mapper)
    : IRequestHandler<GetProductsQuery, ICollection<Product>>
{
    public async Task<ICollection<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var filters = request.Filters;
        int skip = (filters.Page - 1) * filters.PageSize;
        int take = filters.PageSize;

        var spec = new FilteredProductsSpec(
            filters.MinPrice,
            filters.MaxPrice,
            filters.SearchTerm,
            filters.OnlyWithImage,
            filters.SortOrder,
            skip,
            take
        );

        var entities = await repository.ListAsync(spec);
        var products = mapper.Map<ICollection<Product>>(entities);
        return products;
    }
}

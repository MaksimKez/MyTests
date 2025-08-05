using Ardalis.Specification;
using MyTests.DAL.Entities;

namespace MyTests.DAL.Specifications;

public class FilteredProductsSpec : Specification<ProductEntity>
{
    public FilteredProductsSpec(
        int? minPrice,
        int? maxPrice,
        string? searchTerm,
        bool? onlyWithImage,
        string? sortOrder,
        int? skip,
        int? take)
    {
        if (minPrice.HasValue)
        {
            Query.Where(p => p.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            Query.Where(p => p.Price <= maxPrice.Value);
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            Query.Where(p => p.Title.Contains(searchTerm));
        }

        if (onlyWithImage == true)
        {
            Query.Where(p => !string.IsNullOrEmpty(p.ImageUrl));
        }

        if (sortOrder?.ToLower() == "asc")
        {
            Query.OrderBy(p => p.Price);
        }
        else if (sortOrder?.ToLower() == "desc")
        {
            Query.OrderByDescending(p => p.Price);
        }

        if (skip.HasValue)
        {
            Query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            Query.Take(take.Value);
        }
    }
}

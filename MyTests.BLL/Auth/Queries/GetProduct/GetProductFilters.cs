namespace MyTests.BLL.Auth.Queries.GetProduct;

public class GetProductFilters
{
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
    public string? SearchTerm { get; set; }
    public bool? OnlyWithImage { get; set; }
    public string? SortOrder { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
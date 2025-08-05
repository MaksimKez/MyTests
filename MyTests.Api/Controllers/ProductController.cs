using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyTests.BLL.Auth.Queries.GetProduct;

namespace MyTests.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductFilters filters)
    {
        var products = await mediator.Send(new GetProductsQuery(filters));
        return Ok(products);
    }
}
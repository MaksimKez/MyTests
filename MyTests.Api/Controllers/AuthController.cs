using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyTests.BLL.Auth.Commands;
using MyTests.BLL.Auth.Commands.RegisterUser;

namespace MyTests.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(new { Id = userId });
    }
}
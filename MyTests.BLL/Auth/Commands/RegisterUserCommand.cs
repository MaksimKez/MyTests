using MediatR;
using MyTests.BLL.Models;

namespace MyTests.BLL.Auth.Commands;

public record RegisterUserCommand(string Email, string Password) : IRequest<Guid>;

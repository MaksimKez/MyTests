using MediatR;

namespace MyTests.BLL.Auth.Commands.RegisterUser;

public record RegisterUserCommand(string Email, string Password) : IRequest<Guid>;

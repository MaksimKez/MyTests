using AutoMapper;
using MediatR;
using MyTests.BLL.Models;
using MyTests.BLL.Services.Auth.Contracts;
using MyTests.DAL.Entities;
using MyTests.DAL.Repositories.Contracts;

namespace MyTests.BLL.Auth.Commands.RegisterUser;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUnitOfWork _uow;
    private readonly IPasswordHasher _hasher;
    private readonly IMapper _mapper;

    public RegisterUserHandler(IUnitOfWork uow, IPasswordHasher hasher, IMapper mapper)
    {
        _uow = uow;
        _hasher = hasher;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existing = await _uow.Users.GetByEmailAsync(request.Email);
        if (existing != null)
            throw new Exception("User with this email already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = _hasher.HashPassword(request.Password),
            IsVerified = false
        };

        await _uow.Users.AddAsync(_mapper.Map<UserEntity>(user));
        await _uow.SaveChangesAsync();

        return user.Id;
    }
}

using Microsoft.IdentityModel.Tokens;
using TaskApi.Dto.User;
using TaskApi.Entities;
using TaskApi.Repositories;

namespace TaskApi.Services;

public class UserService
{
    private readonly UserRepository _repository;

    public UserService(UserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDto> CreateAsync(UserCreateDto dto, CancellationToken ct)
    {
        if (dto.email.IsNullOrEmpty() || dto.password.IsNullOrEmpty()) return null;
        // ToDO encrypt password before save
        var user = new User(dto.email, dto.password);
        var entity = await _repository.createdAsync(user);
        return new UserDto(entity);
    }

    public User GetByEmail(String email)
    {
        if (email.IsNullOrEmpty()) return null;
        return _repository.GetByEmail(email);
    }
}
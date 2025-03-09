using TaskApi.Dto.User;

namespace TaskApi.Services;

public class AuthService
{
    private readonly UserService _userService;

    public AuthService(UserService userService)
    {
        _userService = userService;
    }

    public bool Auth(UserAuth userAuth)
    {
        var entity = _userService.GetByEmail(userAuth.Email);
        if (entity == null) return false;
        return userAuth.Password.Equals(entity.Password);
    }
}
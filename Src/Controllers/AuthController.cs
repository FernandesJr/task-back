using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Dto.User;
using TaskApi.Services;

namespace TaskApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController: ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly AuthService _authService;

    public AuthController(TokenService tokenService, AuthService authService)
    {
        _tokenService = tokenService;
        _authService = authService;
    }

    [HttpPost()]
    public IActionResult Login(UserAuth auth)
    {
        if (_authService.Auth(auth))
        {
            var token = _tokenService.GenerateToken(auth.Email);
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }
    
}
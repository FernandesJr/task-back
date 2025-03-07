using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Services;

namespace TaskApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController: ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost()]
    public IActionResult Login(LoginRequest request)
    {
        //ToDo auth with Db
        if (request.Email == "fer@email.com" && request.Password == "passhere") // Simulação de usuário fixo
        {
            var token = _tokenService.GenerateToken(request.Email);
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }   
    
}
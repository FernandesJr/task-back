using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Dto.User;
using TaskApi.Services;

namespace TaskApi.Controllers;

[Route("api/users")]
[ApiController]
[Authorize]
public class UserController
{

    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Create(UserCreateDto dto, CancellationToken ct)
    {
        var userDto = await _service.CreateAsync(dto, ct);
        if (userDto == null) return null;
        //return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        return userDto;
    }

}
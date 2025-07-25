using Dtos;
using IServiceLogic;
using Yorugua.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Yorugua.Controllers;
[Route("api/v1/users")]
[ApiController]
[ExceptionFilters]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserLoginRegisterDto loginRegisterDto)
    {
        _userService.Register(loginRegisterDto.Username, loginRegisterDto.Password);
        return CreatedAtAction(nameof(Register), new { username = loginRegisterDto.Username }, null);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRegisterDto loginRegisterDto)
    {
        var token = _userService.Login(loginRegisterDto.Username, loginRegisterDto.Password);
        return Ok(new { token });
    }
}
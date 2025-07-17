using Dtos;
using IServiceLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Yorugua.Controllers;
[Route("api/v1/users")]
[ApiController]

public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserLoginRegisterDto loginRegisterDto)
    {
        _userService.Register(loginRegisterDto.Username, loginRegisterDto.Password, loginRegisterDto.Balance);
        return Ok("Usuario creado");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRegisterDto loginRegisterDto)
    {
        var token = _userService.Login(loginRegisterDto.Username, loginRegisterDto.Password);
        return Ok(new { token });
    }
}
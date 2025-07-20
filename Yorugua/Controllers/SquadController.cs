using Dtos;
using IServiceLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yorugua.Filters;

namespace Yorugua.Controllers;

[Route("api/v1/squad")]
[ApiController]
[ExceptionFilters]
public class SquadController(ISquadService squadService) : ControllerBase
{
    private readonly ISquadService _squadService = squadService;
    
    [HttpGet("{username}")]
    [Authorize]
    public async Task<IActionResult> GetSquad([FromRoute] string username)
    {
        var players = _squadService.GetSquadByUsername(username);
        return Ok(players);
    }
    
    
    /*
    [HttpPost("//agregar")]
    [Authorize]
    public async Task<IActionResult> AddPlayer([FromBody] PlayerDto player)
    {
        try
        {
            _squadService.CreateTeam(team);
            return Ok(team);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    */
}
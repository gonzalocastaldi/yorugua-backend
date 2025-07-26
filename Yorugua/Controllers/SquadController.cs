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
    
    [HttpPost("{squadId}/add-player")]
    [Authorize]
    public async Task<IActionResult> AddPlayer(Guid squadId, [FromBody] PlayerIdDto playerId)
    {
        _squadService.AddPlayer(squadId ,playerId);
        return Ok(squadId);
    }

    [HttpPost("{squadId}/delete-player")]
    [Authorize]
    public async Task<IActionResult> DeletePlayer(Guid squadId, [FromBody] PlayerIdDto player)
    {
        _squadService.DeletePlayer(squadId, player);
        return Ok(squadId);
    }
}
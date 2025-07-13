using IServiceLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Yorugua.Controllers;
[Route("api/v1/players")]
[ApiController]

public class PlayerController(IPlayerService playerService) : ControllerBase
{
    private readonly IPlayerService _playerService = playerService;
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllPlayers()
    {
        var players = _playerService.GetAllPlayers();
        return Ok(players);
    }
    
    [HttpGet("{playerId}")]
    [Authorize]
    public async Task<IActionResult> GetPlayerById(Guid playerId)
    {
        if (playerId == Guid.Empty)
        {
            return BadRequest("Player ID cannot be empty.");
        }

        try
        {
            var player = _playerService.GetPlayerById(playerId);
            return Ok(player);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
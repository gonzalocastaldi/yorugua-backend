using Dtos;
using IServiceLogic;
using Microsoft.AspNetCore.Mvc;
using Yorugua.Filters;

namespace Yorugua.Controllers;

[Route("api/v1/teams")]
[ApiController]
[ExceptionFilters]
public class TeamController(ITeamService teamService) : ControllerBase
{
    private readonly ITeamService _teamService = teamService;
    
    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = _teamService.GetAllTeams();
        return Ok(teams);
    }
    
    [HttpGet("{teamId}")]
    public async Task<IActionResult> GetTeamById(Guid teamId)
    {
        if (teamId == Guid.Empty)
        {
            return BadRequest("Team ID cannot be empty.");
        }

        try
        {
            var team = _teamService.GetTeamById(teamId);
            return Ok(team);
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
    
    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] List<TeamDto> team)
    {
        try
        {
            _teamService.CreateTeam(team);
            return Ok(team);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
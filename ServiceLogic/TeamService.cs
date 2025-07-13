using Domain;
using Dtos;
using IDataAccess;
using IServiceLogic;

namespace ServiceLogic;

public class TeamService(ITeamRepository teamRepository) : ITeamService
{
    private readonly ITeamRepository _teamRepository = teamRepository;
    
    public List<TeamDto> GetAllTeams()
    {
        var teams = _teamRepository.GetAllTeams();
        var teamsToReturn = new List<TeamDto>();
        foreach (var t in teams)
        {
            var teamDto = new TeamDto
            {
                Name = t.Name,
                Players = t.Players.Select(p => new PlayerDto
                {
                    Name = p.Name,
                    Lastname = p.Lastname,
                    Position = p.Position
                }).ToList()
            };
            teamsToReturn.Add(teamDto);
        }
        return teamsToReturn;
    }
    
    public TeamDto GetTeamById(Guid teamId)
    {
        if (teamId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(teamId), "Team ID cannot be empty.");
        }

        var team = _teamRepository.GetTeamById(teamId);
        
        if (team == null)
        {
            throw new KeyNotFoundException($"Team with ID {teamId} not found.");
        }
        
        return new TeamDto
        {
            Name = team.Name,
            Players = team.Players.Select(p => new PlayerDto
            {
                Name = p.Name,
                Lastname = p.Lastname,
                Position = p.Position
            }).ToList()
        };
    }
    
    public void CreateTeam(List<TeamDto> teams)
    {
        foreach (var t in teams)
        {
            var teamToCreate = new Team
            {
                Name = t.Name,
                Players = t.Players.Select(p => new Player
                {
                    Name = p.Name,
                    Lastname = p.Lastname,
                    Position = p.Position
                }).ToList()
            };
            _teamRepository.CreateTeam(teamToCreate);
        }
    }
}
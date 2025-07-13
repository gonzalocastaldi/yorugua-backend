using Domain;
using Dtos;

namespace IServiceLogic;

public interface ITeamService
{
    public List<TeamDto> GetAllTeams();
    public TeamDto GetTeamById(Guid teamId);
    public void CreateTeam(List<TeamDto> team);
}
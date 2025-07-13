using Domain;

namespace IDataAccess;

public interface ITeamRepository
{
    public List<Team> GetAllTeams();
    public Team GetTeamById(Guid teamId);
    public void CreateTeam(Team team);
}
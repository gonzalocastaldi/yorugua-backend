using Domain;
using IDataAccess;

namespace DataAccess.Repositories;

public class TeamRepository(AppDbContext dbContext) : ITeamRepository
{
    public List<Team> GetAllTeams()
    {
        try
        {
            return dbContext.Set<Team>().ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving teams.", ex);
        }
    }
    
    public Team GetTeamById(Guid teamId)
    {
        if (teamId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(teamId), "Team ID cannot be empty.");
        }

        try
        {
            return dbContext.Set<Team>().FirstOrDefault(t => t.Id == teamId);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the team with ID {teamId}.", ex);
        }
    }
    
    public void CreateTeam(Team team)
    {
        if (team == null)
        {
            throw new ArgumentNullException(nameof(team), "Team cannot be null.");
        }

        try
        {
            dbContext.Set<Team>().Add(team);
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating the team.", ex);
        }
    }
}
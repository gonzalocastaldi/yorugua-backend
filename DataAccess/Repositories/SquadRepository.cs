using Domain;
using IDataAccess;

namespace DataAccess.Repositories;

public class SquadRepository(AppDbContext dbContext) : ISquadRepository
{
    public void CreateSquad(Squad squad)
    {
        if (squad == null)
            throw new ArgumentNullException(nameof(squad), "Squad cannot be null.");
        
        try
        {
            dbContext.Set<Squad>().Add(squad);
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating the squad.", ex);
        }
    }
    
    public Squad GetSquadById(Guid squadId)
    {
        if (squadId == Guid.Empty)
            throw new ArgumentNullException(nameof(squadId), "Squad ID cannot be empty.");

        try
        {
            return dbContext.Set<Squad>().FirstOrDefault(s => s.Id == squadId);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the squad with ID {squadId}.", ex);
        }
    }
    
    public Squad GetSquadByUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
            throw new ArgumentNullException(nameof(username), "Username cannot be null or empty.");

        try
        {
            var toReturn = dbContext.Set<User>().FirstOrDefault(s => s.Username == username )?.Squad;
            if (toReturn == null)
                throw new KeyNotFoundException($"Squad for user {username} not found.");
            return toReturn;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the squad for user {username}.", ex);
        }
    }

    public void AddPlayer(Guid squadId, Player player)
    {
        var squad = GetSquadById(squadId);
        
        if(squad == null)
            throw new ArgumentNullException(nameof(squad), "Squad cannot be null.");
        
        if(player == null)
            throw new ArgumentNullException(nameof(player), "Player cannot be null.");

        try
        {
            dbContext.Set<Player>().Add(player);
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while adding player to the squad.", ex);
        }
    }
}
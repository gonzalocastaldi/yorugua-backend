using Domain;
using IDataAccess;

namespace DataAccess.Repositories;

public class PlayerRepository(AppDbContext dbContext) : IPlayerRepository
{
    public List<Player> GetAllPlayers()
    {
        try
        {
            return dbContext.Set<Player>().ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving players.", ex);
        }
    }
    
    public Player GetPlayerById(Guid playerId)
    {
        if (playerId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(playerId), "Player ID cannot be empty.");
        }

        try
        {
            return dbContext.Set<Player>().FirstOrDefault(p => p.Id == playerId);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the player with ID {playerId}.", ex);
        }
    }
}
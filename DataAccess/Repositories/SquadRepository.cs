using Domain;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

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
            return dbContext.Set<Squad>().Include(s => s.Players).FirstOrDefault(s => s.Id == squadId);
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
            var userId = dbContext.Users
                .Where(u => u.Username == username)
                .Select(u => u.Id)
                .FirstOrDefault();
            if (userId == Guid.Empty)
                throw new KeyNotFoundException($"User with username {username} not found.");
            
            var toReturn = dbContext.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Squad)
                .ThenInclude(s => s.Players)
                .Select(u => u.Squad)
                .FirstOrDefault();
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
            squad.Players.Add(player);
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while adding player to the squad.", ex);
        }
    }
    
    public Player GetPlayerById(Guid playerId)
    {
        if (playerId == Guid.Empty)
            throw new ArgumentNullException(nameof(playerId), "Player ID cannot be empty.");

        try
        {
            return dbContext.Set<Player>().FirstOrDefault(p => p.Id == playerId);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the player with ID {playerId}.", ex);
        }
    }
    
    public void DeletePlayer(Guid squadId, Player player)
    {
        if (squadId == Guid.Empty)
            throw new ArgumentNullException(nameof(squadId), "Squad ID cannot be empty.");
        
        if (player == null)
            throw new ArgumentNullException(nameof(player), "Player cannot be null.");

        var squad = GetSquadById(squadId);
        
        if(squad == null)
            throw new KeyNotFoundException($"Squad with ID {squadId} not found.");

        try
        {
            dbContext.Set<Player>().Remove(player);
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while deleting the player from the squad.", ex);
        }
    }
}
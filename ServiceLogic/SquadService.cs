using Domain;
using IDataAccess;
using IServiceLogic;

namespace ServiceLogic;

public class SquadService(ISquadRepository squadRepository) : ISquadService
{
    private readonly ISquadRepository _squadRepository = squadRepository;
    
    public void CreateSquad(Squad squad)
    {
        if (squad == null)
            throw new ArgumentNullException(nameof(squad), "Squad cannot be null.");
        
        _squadRepository.CreateSquad(squad);
    }
    
    public Squad GetSquadById(Guid squadId)
    {
        if (squadId == Guid.Empty)
            throw new ArgumentNullException(nameof(squadId), "Squad ID cannot be empty.");
        
        var squad = _squadRepository.GetSquadById(squadId);
        
        if (squad == null)
            throw new KeyNotFoundException($"Squad with ID {squadId} not found.");
        
        return squad;
    }
    
    public void AddPlayer(Guid squadId, Player player)
    {
        if (squadId == Guid.Empty)
            throw new ArgumentNullException(nameof(squadId), "Squad ID cannot be empty.");
        
        if (player == null)
            throw new ArgumentNullException(nameof(player), "Player cannot be null.");
        
        var squad = _squadRepository.GetSquadById(squadId);
        
        if (squad == null)
            throw new KeyNotFoundException($"Squad with ID {squadId} not found.");
        
        _squadRepository.AddPlayer(squadId, player);
    }
    
    public Squad GetSquadByUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
            throw new ArgumentNullException(nameof(username), "Username cannot be null or empty.");
        
        var squad = _squadRepository.GetSquadByUsername(username);
        
        if (squad == null)
            throw new KeyNotFoundException($"Squad for user {username} not found.");
        
        return squad;
    }
    
}
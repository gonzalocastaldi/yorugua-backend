using Dtos;
using IDataAccess;
using IServiceLogic;

namespace ServiceLogic;

public class PlayerService(IPlayerRepository playerRepository) : IPlayerService
{
    private readonly IPlayerRepository _playerRepository = playerRepository;

    public List<PlayerDto> GetAllPlayers()
    {
        var players = playerRepository.GetAllPlayers();
        return players.Select(p => new PlayerDto
        {
            Name = p.Name,
            Lastname = p.Lastname,
            Position = p.Position
        }).ToList();
    }

    public PlayerDto GetPlayerById(Guid playerId)
    {
        if (playerId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(playerId), "Player ID cannot be empty.");
        }

        var player = playerRepository.GetPlayerById(playerId);
        
        if (player == null)
        {
            throw new KeyNotFoundException($"Player with ID {playerId} not found.");
        }
        
        return new PlayerDto
        {
            Name = player.Name,
            Lastname = player.Lastname,
            Position = player.Position
        };
    }
}
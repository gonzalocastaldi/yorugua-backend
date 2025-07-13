using Dtos;
using IDataAccess;

namespace IServiceLogic;

public interface IPlayerService
{
    public List<PlayerDto> GetAllPlayers();
    public PlayerDto GetPlayerById(Guid playerId);
}
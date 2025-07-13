using Domain;

namespace IDataAccess;

public interface IPlayerRepository
{
    public List<Player> GetAllPlayers();
    public Player GetPlayerById(Guid playerId);

}
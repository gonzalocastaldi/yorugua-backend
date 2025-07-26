using Domain;

namespace IDataAccess;

public interface ISquadRepository
{
    public void CreateSquad(Squad squad);
    public Squad GetSquadById(Guid squadId);
    public void AddPlayer(Guid squadId, Player player);
    public Squad GetSquadByUsername(string username);
    public Player GetPlayerById(Guid playerId);
    public void DeletePlayer(Guid squadId, Player player);
}
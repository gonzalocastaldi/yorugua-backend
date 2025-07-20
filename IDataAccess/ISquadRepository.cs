using Domain;

namespace IDataAccess;

public interface ISquadRepository
{
    public void CreateSquad(Squad squad);
    public Squad GetSquadById(Guid squadId);
    public void AddPlayer(Guid squadId, Player player);
    public Squad GetSquadByUsername(string username);
}
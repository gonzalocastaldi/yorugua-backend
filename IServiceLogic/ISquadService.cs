using Domain;

namespace IServiceLogic;

public interface ISquadService
{
    public void CreateSquad(Squad squad);
    public Squad GetSquadById(Guid squadId);
    public void AddPlayer(Guid squadId, Player player);
    public Squad GetSquadByUsername(string username);
}
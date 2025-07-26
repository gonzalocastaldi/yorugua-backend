using Domain;
using Dtos;

namespace IServiceLogic;

public interface ISquadService
{
    public void CreateSquad(Squad squad);
    public Squad GetSquadById(Guid squadId);
    public void AddPlayer(Guid squadId, PlayerIdDto player);
    public Squad GetSquadByUsername(string username);
    public void DeletePlayer(Guid squadId, PlayerIdDto player);
}
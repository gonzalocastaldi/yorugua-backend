using Dtos;

namespace IServiceLogic;

public interface IUserService
{
    public List<User> GetAllUsers();
    public User? GetUserByName(string username);
    public string Login(string username, string password);
    public void Register(string username, string password);
}
using Domain;

namespace IDataAccess;

public interface IUserRepository
{
    public List<User> GetAllUsers();
    public User GetUserByName(string username);
    public void CreateUser(User user);
    public void DeleteUser(string username);
}
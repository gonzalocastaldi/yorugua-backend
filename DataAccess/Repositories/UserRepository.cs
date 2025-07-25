using Domain;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public List<User> GetAllUsers()
    {
        try
        {
            return dbContext.Set<User>().ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving users.", ex);
        }
    }
    
    public User GetUserByName(string userName)
    {
        try
        {
            return dbContext.Set<User>().FirstOrDefault(u => u.Username == userName);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the user with name {userName}.", ex);
        }
    }

    public void CreateUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }

        try
        {
            dbContext.Set<User>().Add(user);
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating the user.", ex);
        }
    }
    
    public void DeleteUser(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            throw new ArgumentNullException(nameof(userName), "User name cannot be null or empty.");
        }

        try
        {
            var user = dbContext.Set<User>().FirstOrDefault(u => u.Username == userName);
            if (user == null)
            {
                throw new Exception($"User with name {userName} does not exist.");
            }

            dbContext.Set<User>().Remove(user);
            dbContext.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occurred while deleting the user.", ex);
        }
    }
}
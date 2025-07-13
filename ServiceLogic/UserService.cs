using System.Security.Claims;
using System.Text;
using IDataAccess;
using IServiceLogic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ServiceLogic;

public class UserService(IUserRepository userRepository, IConfiguration config) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IConfiguration _config = config;
    
    public List<User> GetAllUsers()
    {
        try
        {
            return _userRepository.GetAllUsers();
        }
        catch (Exception exception)
        {
            throw new Exception($"Error retrieving users: {exception.Message}");
        }
    }
    
    public User GetUserByName(string userName)
    {
        try
        {
            return _userRepository.GetUserByName(userName);
        }
        catch (Exception exception)
        {
            throw new Exception($"Error retrieving user by name '{userName}': {exception.Message}");
        }
    }

    public void Register(string username, string password, double balance)
    {
        if (_userRepository.GetAllUsers().Any(u => u.Username == username))
            throw new Exception("El usuario ya existe.");

        CreatePasswordHash(password, out var hash, out var salt);

        var user = new User
        {
            Username = username,
            PasswordHash = hash,
            PasswordSalt = salt,
            Balance = balance
        };

        _userRepository.CreateUser(user);
    }
    
    private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        salt = hmac.Key;
        hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }
    
    public string Login(string username, string password)
    {
        var user = _userRepository.GetAllUsers().FirstOrDefault(u => u.Username == username) 
                   ?? throw new Exception("User not found.");

        if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new Exception("Incorrect password.");

        return CrearToken(user);
    }
    
    private bool VerifyPasswordHash(string password, byte[] hashGuardado, byte[] saltGuardado)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512(saltGuardado);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(hashGuardado);
    }
    
    private string CrearToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key no configurado")));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
using Domain;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public double Balance { get; set; }
    public Squad Squad { get; set; } = new Squad();

    public User() { }

    public User(string username, string password, double balance)
    {
        Username = username;
        Balance = balance;

        CrearPasswordHash(password, out byte[] hash, out byte[] salt);
        PasswordHash = hash;
        PasswordSalt = salt;
    }

    private void CrearPasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        salt = hmac.Key;
        hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }
    
}
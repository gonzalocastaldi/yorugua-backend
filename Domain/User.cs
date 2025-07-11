namespace Domain;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string Password { get; set; }
    public double Balance { get; set; }
    public Team? Team { get; set; }

    public User() { }
    
    public User(string username, string password, double balance)
    {
        Username = username;
        Password = password;
        Balance = balance;
    }
}
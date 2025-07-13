namespace Domain;

public class League
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<User> Users { get; set; } = [];

    public League() { }
    
    public League(List<User> users)
    {
        Users = users;
    }
}

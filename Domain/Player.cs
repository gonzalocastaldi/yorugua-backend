namespace Domain;

public class Player
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Lastname { get; set; }
    public Position Position { get; set; }
    public int Points { get; set; }
    public int Goals { get; set; }
    public int Assists { get; set; }
    public int RedCards { get; set; }
    public int YellowCards { get; set; }
    public Team Team { get; set; }
    public Guid TeamId { get; set; }
    public ICollection<Squad> Squads { get; set; }

    public Player() { }
    
    public Player(string name, string lastname, Position position)
    {
        Name = name;
        Lastname = lastname;
        Position = position;
    }
}
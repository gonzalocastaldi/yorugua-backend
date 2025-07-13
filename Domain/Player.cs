namespace Domain;

public class Player
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Lastname { get; set; }
    public Position Position { get; set; }

    public Player() { }
    
    public Player(string name, string lastname, Position position)
    {
        Name = name;
        Lastname = lastname;
        Position = position;
    }
}
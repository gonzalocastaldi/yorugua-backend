namespace Domain;

public class Team
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<Player> Players { get; set; } = new();
    public int Points { get; set; }
    public int GoalsInFavor { get; set; }
    public int GoalsAgainst { get; set; }
    
    public Team() { }
    
    public Team(string name, List<Player> players)
    {
        Name = name;
        Players = players;
        Points = 0;
        GoalsInFavor = 0;
        GoalsAgainst = 0;
    }
}
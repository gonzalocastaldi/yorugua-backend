namespace Domain;

public class Squad
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public ICollection<Player> Players { get; set; }

    public Squad()
    {
        Name = "Mi equipo";
        Players = new List<Player>();
    }
}
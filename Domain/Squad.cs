namespace Domain;

public class Squad
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Player> Players { get; set; }

    public Squad() { }
}
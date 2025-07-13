namespace Domain;

public class Team
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public Formation Formation { get; set; }
    
    public Team() { }
    
    public Team(string name, Formation formation)
    {
        Name = name;
        Formation = formation;
    }
}
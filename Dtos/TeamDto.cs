namespace Dtos;

public class TeamDto
{
    public string Name { get; set; }
    public List<PlayerDto> Players { get; set; } = new();
}
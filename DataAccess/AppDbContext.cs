using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<League>? Leagues { get; set; }
    public DbSet<Team>? Teams { get; set; }
    public DbSet<Player>? Players { get; set; }
    public DbSet<User>? Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relación Player - Team (Un jugador pertenece a un equipo)
        modelBuilder.Entity<Player>()
            .HasOne(p => p.Team)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TeamId);
        
        base.OnModelCreating(modelBuilder);
    }
}
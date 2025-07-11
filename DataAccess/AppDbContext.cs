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
        base.OnModelCreating(modelBuilder);
    }
}
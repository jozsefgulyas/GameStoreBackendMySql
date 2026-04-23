using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Role-Playing Game (RPG)" },
            new { Id = 2, Name = "Action-Adventure" },
            new { Id = 3, Name = "Sandbox / Survival" },
            new { Id = 4, Name = "First-Person Shooter (FPS)" },
            new { Id = 5, Name = "Strategy" },
            new { Id = 6, Name = "Racing / Simulation" },
            new { Id = 7, Name = "Platformer / Indie" },
            new { Id = 8, Name = "Life Simulation" },
            new { Id = 9, Name = "Puzzle / Cooperative" },
            new { Id = 10, Name = "Horror" }
        );
    }
}

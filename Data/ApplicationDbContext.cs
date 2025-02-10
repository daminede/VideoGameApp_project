using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGameApp.Data;
using VideoGameApp.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<VideoGame> VideoGame { get; set; } = default!;
    public DbSet<Developer> Developers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ✅ Ensure Description is Included in Seed Data
        modelBuilder.Entity<VideoGame>().HasData(
            new VideoGame
            {
                Id = 1,
                Title = "The Witcher 3",
                DeveloperId = 1,
                Genre = "RPG",
                ReleaseDate = new DateTime(2015, 5, 19),
                Price = 39.99m,
                Description = "An open-world RPG set in a stunning fantasy universe filled with meaningful choices and impactful consequences."
            },
            new VideoGame
            {
                Id = 2,
                Title = "Cyberpunk 2077",
                DeveloperId = 1,
                Genre = "RPG",
                ReleaseDate = new DateTime(2020, 12, 10),
                Price = 59.99m,
                Description = "A narrative-driven, open-world RPG set in the vibrant and dangerous metropolis of Night City."
            }
        );
    }


}

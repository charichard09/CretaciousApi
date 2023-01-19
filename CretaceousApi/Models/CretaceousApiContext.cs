using Microsoft.EntityFrameworkCore;

namespace CretaceousApi.Models;

public class CretaceousApiContext : DbContext
{
  public DbSet<Animal> Animals { get; set; }
  public DbSet<Continent> Continents { get; set; }
  public DbSet<ContinentAnimal> ContinentAnimals { get; set; }

  public CretaceousApiContext(DbContextOptions<CretaceousApiContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Animal>()
      .HasData(
        new Animal { AnimalId = 1, Name = "Buck", Species = "Diplodocus", Age = 100 },
        new Animal { AnimalId = 2, Name = "Bubbles", Species = "Triceratops", Age = 50 },
        new Animal { AnimalId = 3, Name = "Spot", Species = "Velociraptor", Age = 2 }
      );
    
    builder.Entity<Continent>()
      .HasData(
        new Continent { ContinentId = 1, Name = "North America" },
        new Continent { ContinentId = 2, Name = "South America" },
        new Continent { ContinentId = 3, Name = "Africa" },
        new Continent { ContinentId = 4, Name = "Europe" },
        new Continent { ContinentId = 5, Name = "Asia" },
        new Continent { ContinentId = 6, Name = "Australia" }
      );
  }
}
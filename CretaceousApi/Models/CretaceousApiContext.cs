using Microsoft.EntityFrameworkCore;

namespace CretaceousApi.Models;

public class CretaceousApiContext : DbContext
{
  public DbSet<Animal> Animals { get; set; }

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
  }
}
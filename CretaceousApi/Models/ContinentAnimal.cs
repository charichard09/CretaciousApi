namespace CretaceousApi.Models;

public class ContinentAnimal
{
  public int ContinentAnimalId { get; set; }
  public int ContinentId { get; set; }
  public int AnimalId { get; set; }
  public virtual Continent Continent { get; set; }
  public virtual Animal Animal { get; set; }
}
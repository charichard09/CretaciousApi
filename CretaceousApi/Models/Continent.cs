namespace CretaceousApi.Models;

public class Continent
{
  public int ContinentId { get; set; }
  public string Name { get; set; }
  public ICollection<ContinentAnimal> JoinEntities { get; set; }
}
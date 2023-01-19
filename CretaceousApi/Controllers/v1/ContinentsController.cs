using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CretaceousApi.Models;

namespace CretaceousApi.Controllers.v1;

[Route("api/v{version:apiVersion}/[Controller]")]
[ApiController]
[ApiVersion("1.0")]
public class ContinentsController : ControllerBase
{
  private CretaceousApiContext _db;

  public ContinentsController(CretaceousApiContext db)
  {
    _db = db;
  }

  // GET api/continent
  [HttpGet]
  public async Task<List<Continent>> Get(string name)
  {
    IQueryable<Continent> query = _db.Continents.AsQueryable();
    // IQueryable<Continent> query = _db.Continents.Include(join => join.JoinEntities).ThenInclude(join => join.Animal).AsQueryable();

    if (name != null)
    {
      query = query.Where(entry => entry.Name == name);
    }

    return await query.ToListAsync();
  }

  // GET api/continent/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<Continent>> GetContinent(int id)
  {
    Continent continent = await _db.Continents.FindAsync(id);

    if (continent == null)
    {
      return NotFound();
    }

    return continent;
  }

  // Post api/continent
  [HttpPost]
  public async Task<ActionResult<Continent>> Post(Continent continent)
  {
    _db.Continents.Add(continent);
    await _db.SaveChangesAsync();
    
    return CreatedAtAction(nameof(GetContinent), new { id = continent.ContinentId }, continent);
  }

  // Put api/continent/{id}
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Continent continent)
  {
    if (id != continent.ContinentId)
    {
      return BadRequest();
    }

    _db.Continents.Update(continent);

    try
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!ContinentExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }

    return NoContent();
  }

  private bool ContinentExists(int id)
  {
    return _db.Continents.Any(e => e.ContinentId == id);
  }

  // Delete api/continent/{id}
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteContinent(int id)
  {
    Continent continent = await _db.Continents.FindAsync(id);
    if (continent == null)
    {
      return NotFound();
    }

    _db.Continents.Remove(continent);
    await _db.SaveChangesAsync();

    return NoContent();
  }

  // Put animal to continent
  [HttpPost("{continentId}/animals/{animalId}")]
  public async Task<IActionResult> AddAnimal(int continentId, int animalId)
  {
    if (!ContinentExists(continentId))
    {
      return NotFound();
    }

    if (!AnimalExists(animalId))
    {
      return NotFound();
    }

    #nullable enable
    ContinentAnimal? joinEntity = await _db.ContinentAnimals.FirstOrDefaultAsync(entry => entry.ContinentId == continentId && entry.AnimalId == animalId);
    #nullable disable

    if (joinEntity == null)
    {
      _db.ContinentAnimals.Add( new ContinentAnimal() { ContinentId = continentId, AnimalId = animalId } );
    }

    await _db.SaveChangesAsync();

    return NoContent();
  }

  private bool AnimalExists(int id)
  {
    return _db.Animals.Any(e => e.AnimalId == id);
  }

  // Get a continents animals
  [HttpGet("{id}/animals")]
  public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals(int id)
  {
    Continent continent = await _db.Continents.Include(join => join.JoinEntities).ThenInclude(join => join.Animal).FirstOrDefaultAsync(continent => continent.ContinentId == id);

    if (continent == null)
    {
      return NotFound();
    }

    List<Animal> animals = new List<Animal>();

    foreach (ContinentAnimal joinEntity in continent.JoinEntities)
    {
      animals.Add(joinEntity.Animal);
    }

    return animals;
  }
}
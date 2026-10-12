using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/villa")]
public class VillaController : ControllerBase
{
    private readonly AppDbContext _db;

    public VillaController(AppDbContext db) => _db = db;

    // GET /api/villa
    [HttpGet]
    public async Task<ActionResult<List<Villa>>> GetAllVillas()
    {
        return Ok(await _db.Villas.AsNoTracking().ToListAsync());
    }

    // GET /api/villa/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Villa>> GetVilla(int id)
    {

        try
        {
        if(id <= 0)
        {
            return BadRequest("Invalid villa ID.");
        }
        var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
        if(villa == null)
        {
            return NotFound($"Villa with ID {id} not found.");
        }
        return villa;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

    }

        // POST
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Villa>> CreateVilla(CreateVillaDto dto)
    {
        var villa = new Villa
        {
            Name = dto.Name,
            Rate = dto.Rate
        };

        try
        {
        await _db.Villas.AddAsync(villa);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVilla), new { id = villa.Id }, villa);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error while creating Villa: {ex.Message}");
        }

    }

    // PUT /api/villa/1
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Villa>> UpdateVilla(int id, UpdateVillaDto dto)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest("Invalid villa ID.");
            }

            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
            if (villa == null)
            {
                return NotFound($"Villa with ID {id} not found.");
            }

            villa.Name = dto.Name;
            villa.Rate = dto.Rate;

            await _db.SaveChangesAsync();

            return Ok(villa);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error while updating Villa: {ex.Message}");
        }
    }

    // DELETE /api/villa/1
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVilla(int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest("Invalid villa ID.");
            }

            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
            if (villa == null)
            {
                return NotFound($"Villa with ID {id} not found.");
            }

            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error while deleting Villa: {ex.Message}");
        }
    }
}

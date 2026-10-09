using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/villa")]
public class VillaController : ControllerBase
{

    // GET /api/villa
    [HttpGet]
    public string GetAllVillas()
    {
        return "Villas Get All";
    }

    [HttpGet("{id:int}")]
    public string GetVilla(int id)
    {
        return $"Villa Get: {id}";
    }

    [HttpGet("{id:int}/{name}")]
    public string GetVillaAndName([FromRoute] int id, [FromRoute] string name)
    {
        return $"Villa Get: {id}, Name: {name}";
    }
}


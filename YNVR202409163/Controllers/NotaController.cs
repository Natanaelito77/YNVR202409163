using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class NotaController : ControllerBase
{
    private static List<Nota> Notas = new List<Nota>();

    // Endpoint público
    [HttpGet("obtenerNotas")]
    public IActionResult ObtenerNotas()
    {
        return Ok(Notas);
    }

    // Endpoint privado para registrar notas
    [Authorize]
    [HttpPost("registrarNota")]
    public IActionResult RegistrarNota([FromBody] Nota nuevaNota)
    {
        Notas.Add(nuevaNota);
        return Ok(new { message = "Nota registrada con éxito" });
    }
}

public class Nota
{
    public int Id { get; set; }
    public string Materia { get; set; }
    public double Calificacion { get; set; }
}

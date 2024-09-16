using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize] // Todos los endpoints requieren autenticación
public class MatriculaController : ControllerBase
{
    private static List<Matricula> Matriculas = new List<Matricula>();

    [HttpPost("crearMatricula")]
    public IActionResult CrearMatricula([FromBody] Matricula nuevaMatricula)
    {
        Matriculas.Add(nuevaMatricula);
        return Ok(new { message = "Matrícula creada con éxito" });
    }

    [HttpPut("modificarMatricula/{id}")]
    public IActionResult ModificarMatricula(int id, [FromBody] Matricula matriculaModificada)
    {
        var matricula = Matriculas.FirstOrDefault(m => m.Id == id);
        if (matricula == null)
        {
            return NotFound(new { message = "Matrícula no encontrada" });
        }

        matricula.Curso = matriculaModificada.Curso;
        matricula.Estudiante = matriculaModificada.Estudiante;

        return Ok(new { message = "Matrícula modificada con éxito" });
    }

    [HttpGet("obtenerPorIdMatricula/{id}")]
    public IActionResult ObtenerPorIdMatricula(int id)
    {
        var matricula = Matriculas.FirstOrDefault(m => m.Id == id);
        if (matricula == null)
        {
            return NotFound(new { message = "Matrícula no encontrada" });
        }

        return Ok(matricula);
    }
}

public class Matricula
{
    public int Id { get; set; }
    public string Estudiante { get; set; }
    public string Curso { get; set; }
}


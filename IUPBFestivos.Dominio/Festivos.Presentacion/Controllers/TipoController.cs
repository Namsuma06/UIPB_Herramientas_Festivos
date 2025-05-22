using Festivos.Core.Servicios;
using IUPBFestivos.Dominio.Dtos;
using IUPBFestivos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Festivos.Presentacion.Controllers
{
    [ApiController]
    [Route("api/tipo")]
    public class TipoController : ControllerBase
    {
        private readonly ITipoServicio servicio;

        public TipoController(ITipoServicio tipoServicio)
        {
            servicio = tipoServicio;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var tipos = await servicio.ObtenerTodos();
            return Ok(tipos);
        }

        [HttpGet("obtener/{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var tipo = await servicio.Obtener(id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }

        [HttpPost("agregar")]
        public async Task<IActionResult> Agregar([FromBody] Tipo tipo)
        {
            var nuevoTipo = await servicio.Agregar(tipo);
            return CreatedAtAction(nameof(Obtener), new { id = nuevoTipo.Id }, nuevoTipo);
        }

        [HttpPut("modificar/{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] Tipo tipo)
        {
            if (id != tipo.Id) return BadRequest();

            var tipoActualizado = await servicio.Modificar(tipo);
            if (tipoActualizado == null) return NotFound();

            return Ok(tipoActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await servicio.Eliminar(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
        [HttpGet("porTipo/{tipoId}")]
        public async Task<ActionResult<IEnumerable<FestivosportipoDtos>>> ObtenerFestivosConNombreTipo(int tipoId)
        {
            var resultado = await servicio.ObtenerFestivosConNombreTipo(tipoId);

            if (!resultado.Any())
                return NotFound("No se encontraron festivos con ese tipo.");

            return Ok(resultado);
        }
    }
}

using Citas_App.Application.Services;
using Citas_App.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citas_App.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly PacienteService _service;

        public PacientesController(PacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.ObtenerTodos());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var paciente = _service.ObtenerPorId(id);
            return paciente == null ? NotFound() : Ok(paciente);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Paciente paciente)
        {
            _service.Agregar(paciente);
            return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, paciente);
        }
    }
}
using Citas_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citas_App.Controllers
{
    public class CitaController : Controller
    {
        private static List<Cita> _citas = new()
        {
            new Cita { Id = 1, PacienteId = 1, MedicoId = 1, Fecha = new DateOnly(2026, 6, 1), Hora = new TimeOnly(9, 0), Motivo = "Consulta general", Estado = "Confirmada" },
            new Cita { Id = 2, PacienteId = 2, MedicoId = 2, Fecha = new DateOnly(2026, 6, 1), Hora = new TimeOnly(10, 0), Motivo = "Revisión de resultados", Estado = "Pendiente" },
            new Cita { Id = 3, PacienteId = 3, MedicoId = 1, Fecha = new DateOnly(2026, 6, 3), Hora = new TimeOnly(11, 0), Motivo = "Primera consulta", Estado = "Pendiente" }
        };

        public IActionResult Index() => View(_citas);

        public IActionResult PorPaciente(int pacienteId)
        {
            var resultado = _citas.Where(c => c.PacienteId == pacienteId).ToList();
            return View(resultado);
        }

        public IActionResult Detalle(int id)
        {
            var cita = _citas.FirstOrDefault(c => c.Id == id);
            return cita == null ? NotFound() : View(cita);
        }
    }
}
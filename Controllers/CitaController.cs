using Citas_App.Models;
using Microsoft.AspNetCore.Mvc;
namespace Citas_App.Controllers
{
    public class CitaController : Controller
    {
     
        public static List<Cita> Citas = new List<Cita>
        {
            new Cita {
                Id = 1,
                PacienteId = 1,
                MedicoId = 1,
                Fecha = DateOnly.Parse("2026-06-01"),
                Hora = TimeOnly.Parse("09:00"),
                Motivo = "Consulta general",
                Estado = "Confirmada"
            },
            new Cita {
                Id = 2,
                PacienteId = 2,
                MedicoId = 2,
                Fecha = DateOnly.Parse("2026-06-01"),
                Hora = TimeOnly.Parse("10:00"),
                Motivo = "Revisión de resultados",
                Estado = "Pendiente"
            },
            new Cita {
                Id = 3,
                PacienteId = 3,
                MedicoId = 1,
                Fecha = DateOnly.Parse("2026-06-03"),
                Hora = TimeOnly.Parse("11:00"),
                Motivo = "Primera consulta",
                Estado = "Pendiente"
            }
        };

        private void CargarCatalogos()
        {
            ViewBag.Pacientes = PacienteController.Pacientes;
            ViewBag.Medicos = MedicoController.Medicos;
        }

        public IActionResult Index()
        {
            CargarCatalogos();
            return View(Citas);
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            CargarCatalogos();
            var filtradas = Citas.Where(c => c.PacienteId == pacienteId).ToList();
            ViewBag.PacienteSeleccionado = PacienteController.Pacientes.FirstOrDefault(p => p.Id == pacienteId)?.Nombre;
            return View(filtradas);
        }
    }
}
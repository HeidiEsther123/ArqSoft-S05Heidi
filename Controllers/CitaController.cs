using Citas_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class CitaController : Controller
    {
        public static List<Cita> Citas = new List<Cita>
        {
            new Cita { Id=1, PacienteId=1, MedicoId=1, Fecha=new DateOnly(2026,6,1), Hora=new TimeOnly(9,0), Motivo="Consulta general", Estado="Confirmada" },
            new Cita { Id=2, PacienteId=2, MedicoId=2, Fecha=new DateOnly(2026,6,1), Hora=new TimeOnly(10,0), Motivo="Revisión de resultados", Estado="Pendiente" },
            new Cita { Id=3, PacienteId=3, MedicoId=1, Fecha=new DateOnly(2026,6,3), Hora=new TimeOnly(11,0), Motivo="Primera consulta", Estado="Pendiente" }
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
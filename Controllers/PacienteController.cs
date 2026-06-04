using Microsoft.AspNetCore.Mvc;
using Citas_App.Models;
namespace Citas_App.Controllers
{
    public class PacienteController : Controller
    {
        public static List<Paciente> Pacientes = new List<Paciente>
        {
            new Paciente
            {
                Id = 1,
                Nombre = "Ana García",
                Apellido = "",
                Email = "ana@mail.com",
                Telefono = "555-0001"
            },
            new Paciente
            {
                Id = 2,
                Nombre = "Luis Martínez",
                Apellido = "",
                Email = "luis@mail.com",
                Telefono = "555-0002"
            },
            new Paciente
            {
                Id = 3,
                Nombre = "María López",
                Apellido = "",
                Email = "maria@mail.com",
                Telefono = "555-0003"
            }
        };
        public IActionResult Index()
        {
            return View(Pacientes);
        }

        public IActionResult Detalle(int id)
        {
            var paciente = Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }
    }
}
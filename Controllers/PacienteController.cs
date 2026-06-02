using Citas_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citas_App.Controllers
{
    public class PacienteController : Controller
    {
        private static List<Paciente> _pacientes = new()
        {
            new Paciente { Id = 1, Nombre = "Ana García", Email = "ana@mail.com", Telefono = "555-0001" },
            new Paciente { Id = 2, Nombre = "Luis Martínez", Email = "luis@mail.com", Telefono = "555-0002" },
            new Paciente { Id = 3, Nombre = "María López", Email = "maria@mail.com", Telefono = "555-0003" }
        };

        public IActionResult Index() => View(_pacientes);

        public IActionResult Detalle(int id)
        {
            var p = _pacientes.FirstOrDefault(x => x.Id == id);
            return p == null ? NotFound() : View(p);
        }
    }
}

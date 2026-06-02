using Citas_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citas_App.Controllers
{
    public class MedicoController : Controller
    {
        private static List<Medico> _medicos = new()
        {
            new Medico { Id = 1, Nombre = "Dr. Carlos Reyes", Especialidad = "Medicina General", NumeroLicencia = "MG-10421" },
            new Medico { Id = 2, Nombre = "Dra. Patricia Vega", Especialidad = "Pediatría", NumeroLicencia = "PD-20835" },
            new Medico { Id = 3, Nombre = "Dr. Roberto Sánchez", Especialidad = "Cardiología", NumeroLicencia = "CA-30117" }
        };

        public IActionResult Index() => View(_medicos);

        public IActionResult Detalle(int id)
        {
            var m = _medicos.FirstOrDefault(x => x.Id == id);
            return m == null ? NotFound() : View(m);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Citas_App.Models;

namespace Citas_App.Controllers
{
    public class MedicoController : Controller
    {
        public static List<Medico> Medicos = new List<Medico>
        {
            new Medico 
            { 
                Id = 1, 
                Nombre = "Dr. Carlos Reyes", 
                Especialidad = "Medicina General", 
                NumeroLicencia = "MG-10421" 
            },
            new Medico 
            { 
                Id = 2, 
                Nombre = "Dra. Patricia Vega", 
                Especialidad = "Pediatría", 
                NumeroLicencia = "PD-20835" 
            },
            new Medico 
            { 
                Id = 3, 
                Nombre = "Dr. Roberto Sánchez", 
                Especialidad = "Cardiología", 
                NumeroLicencia = "CA-30117" 
            }
        };

        public IActionResult Index()
        {
            return View(Medicos);
        }

        public IActionResult Detalle(int id)
        {
            var medico = Medicos.FirstOrDefault(m => m.Id == id);
            if (medico == null) 
            {
                return NotFound();
            }
            return View(medico);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Citas_App.Models;
using System.Text.Json;

namespace Citas_App.Controllers
{
    public class MedicoController : Controller
    {
        private readonly string _pathMedicos;

        public MedicoController(IWebHostEnvironment env)
        {
            _pathMedicos = Path.Combine(env.ContentRootPath, "data", "medicos.json");
        }

        private List<Medico> ObtenerMedicos()
        {
            if (!System.IO.File.Exists(_pathMedicos))
            {
                return new List<Medico>();
            }
            var json = System.IO.File.ReadAllText(_pathMedicos);
            return JsonSerializer.Deserialize<List<Medico>>(json) ?? new List<Medico>();
        }

        
        public IActionResult Index()
        {
            var medicos = ObtenerMedicos();
            return View(medicos);
        }

        public IActionResult Detalle(int id)
        {
            var medicos = ObtenerMedicos();
            var medico = medicos.FirstOrDefault(m => m.Id == id);
            if (medico == null)
            {
                return NotFound();
            }
            return View(medico);
        }
    }
}
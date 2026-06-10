using Microsoft.AspNetCore.Mvc;
using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;

namespace Citas_App.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _repo;

        public PacienteController(IPacienteRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var pacientes = _repo.ObtenerTodos();
            return View(pacientes);
        }

        public IActionResult Detalle(int id)
        {
            var paciente = _repo.ObtenerPorId(id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Paciente paciente)
        {
            _repo.Agregar(paciente);
            return RedirectToAction("Index");
        }
    }
}
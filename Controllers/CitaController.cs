using Microsoft.AspNetCore.Mvc;
using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;

namespace Citas_App.Controllers
{
    public class CitaController : Controller
    {
        private readonly ICitaRepository _citaRepo;
        private readonly IPacienteRepository _pacienteRepo;
        private readonly IMedicoRepository _medicoRepo;

        public CitaController(ICitaRepository citaRepo,
                              IPacienteRepository pacienteRepo,
                              IMedicoRepository medicoRepo)
        {
            _citaRepo = citaRepo;
            _pacienteRepo = pacienteRepo;
            _medicoRepo = medicoRepo;
        }

        private void CargarCatalogos()
        {
            ViewBag.Pacientes = _pacienteRepo.ObtenerTodos();
            ViewBag.Medicos = _medicoRepo.ObtenerTodos();
        }

        public IActionResult Index()
        {
            CargarCatalogos();
            var citas = _citaRepo.ObtenerTodos();
            return View(citas);
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            CargarCatalogos();
            var filtradas = _citaRepo.ObtenerPorPaciente(pacienteId);
            ViewBag.PacienteSeleccionado = _pacienteRepo.ObtenerPorId(pacienteId)?.Nombre;
            return View(filtradas);
        }
    }
}
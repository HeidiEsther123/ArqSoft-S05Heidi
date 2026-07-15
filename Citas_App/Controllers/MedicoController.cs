using Microsoft.AspNetCore.Mvc;
using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;

namespace Citas_App.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoRepository _repo;

        public MedicoController(IMedicoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var medicos = _repo.ObtenerTodos();
            return View(medicos);
        }

        public IActionResult Detalle(int id)
        {
            var medico = _repo.ObtenerPorId(id);
            if (medico == null) return NotFound();
            return View(medico);
        }
    }
}
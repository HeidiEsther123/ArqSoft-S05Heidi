using Microsoft.AspNetCore.Mvc;
using Citas_App.Models;
using System.Text.Json;

namespace Citas_App.Controllers
{
    public class CitaController : Controller
    {
        private readonly string _pathPacientes;
        private readonly string _pathMedicos;
        private readonly string _pathCitas;

        public CitaController(IWebHostEnvironment env)
        {
            _pathPacientes = Path.Combine(env.ContentRootPath, "data", "pacientes.json");
            _pathMedicos = Path.Combine(env.ContentRootPath, "data", "medicos.json");
            _pathCitas = Path.Combine(env.ContentRootPath, "data", "citas.json");
        }
        private List<Paciente> ObtenerPacientes()
        {
            if (!System.IO.File.Exists(_pathPacientes)) return new List<Paciente>();
            var json = System.IO.File.ReadAllText(_pathPacientes);
            return JsonSerializer.Deserialize<List<Paciente>>(json) ?? new List<Paciente>();
        }

        private List<Medico> ObtenerMedicos()
        {
            if (!System.IO.File.Exists(_pathMedicos)) return new List<Medico>();
            var json = System.IO.File.ReadAllText(_pathMedicos);
            return JsonSerializer.Deserialize<List<Medico>>(json) ?? new List<Medico>();
        }

        private List<Cita> ObtenerCitas
        {
            get
            {
                if (!System.IO.File.Exists(_pathCitas)) return new List<Cita>();
                var json = System.IO.File.ReadAllText(_pathCitas);
                return JsonSerializer.Deserialize<List<Cita>>(json)
                    ?? [];
            }
        }

        private void CargarCatalogos()
        {
            ViewBag.Pacientes = ObtenerPacientes();
            ViewBag.Medicos = ObtenerMedicos();
        }

       
        public IActionResult Index()
        {
            CargarCatalogos();
            var citas = ObtenerCitas;
            return View(citas);
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            CargarCatalogos();
            var citas = ObtenerCitas;
            var filtradas = citas.Where(c => c.PacienteId == pacienteId).ToList();

            var pacientes = ObtenerPacientes();
            ViewBag.PacienteSeleccionado = pacientes.FirstOrDefault(p => p.Id == pacienteId)?.Nombre;

            return View(filtradas);
        }
    }
}
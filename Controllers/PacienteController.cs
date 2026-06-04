using Microsoft.AspNetCore.Mvc;
using Citas_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace Citas_App.Controllers
{
    public class PacienteController : Controller
    {
        private readonly string _pathPacientes;

        public PacienteController(IWebHostEnvironment env)
        {
            _pathPacientes = Path.Combine(env.ContentRootPath, "data", "pacientes.json");
        }

        private List<Paciente> ObtenerPacientes()
        {
            if (!System.IO.File.Exists(_pathPacientes))
            {
                return new List<Paciente>();
            }
            var json = System.IO.File.ReadAllText(_pathPacientes);
            return JsonSerializer.Deserialize<List<Paciente>>(json) ?? new List<Paciente>();
        }

        public IActionResult Index()
        {
            var pacientes = ObtenerPacientes();
            return View(pacientes);
        }

        public IActionResult Detalle(int id)
        {
            var pacientes = ObtenerPacientes();
            var paciente = pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }
    }
}
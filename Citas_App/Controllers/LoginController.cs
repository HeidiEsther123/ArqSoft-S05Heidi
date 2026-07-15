using Microsoft.AspNetCore.Mvc;

namespace Citas_App.Controllers
{
    public class LoginController : Controller
    {
        // Usuarios hardcodeados por ahora
        private static readonly Dictionary<string, (string Password, string Rol)> _usuarios = new()
        {
            { "admin",    ("admin123",    "Admin") },
            { "paciente", ("paciente123", "Paciente") },
            { "medico",   ("medico123",   "Medico") }
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string usuario, string password)
        {
            if (_usuarios.TryGetValue(usuario, out var datos) && datos.Password == password)
            {
                HttpContext.Session.SetString("Usuario", usuario);
                HttpContext.Session.SetString("Rol", datos.Rol);

                return datos.Rol switch
                {
                    "Admin" => RedirectToAction("Index", "Paciente"),
                    "Medico" => RedirectToAction("Index", "Cita"),
                    "Paciente" => RedirectToAction("PorPaciente", "Cita", new { pacienteId = 1 }),
                    _ => RedirectToAction("Index")
                };
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
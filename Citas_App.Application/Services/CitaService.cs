using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;

namespace Citas_App.Application.Services
{
    public class CitaService
    {
        private readonly ICitaRepository _repo;

        public CitaService(ICitaRepository repo)
        {
            _repo = repo;
        }

        public List<Cita> ObtenerTodos() => _repo.ObtenerTodos();
        public List<Cita> ObtenerPorPaciente(int pacienteId) => _repo.ObtenerPorPaciente(pacienteId);
    }
}
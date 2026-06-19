using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;

namespace Citas_App.Application.Services
{
    public class PacienteService
    {
        private readonly IPacienteRepository _repo;

        public PacienteService(IPacienteRepository repo)
        {
            _repo = repo;
        }

        public List<Paciente> ObtenerTodos() => _repo.ObtenerTodos();
        public Paciente? ObtenerPorId(int id) => _repo.ObtenerPorId(id);
        public void Agregar(Paciente paciente) => _repo.Agregar(paciente);
    }
}
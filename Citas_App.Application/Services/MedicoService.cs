using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;

namespace Citas_App.Application.Services
{
    public class MedicoService
    {
        private readonly IMedicoRepository _repo;

        public MedicoService(IMedicoRepository repo)
        {
            _repo = repo;
        }

        public List<Medico> ObtenerTodos() => _repo.ObtenerTodos();
        public Medico? ObtenerPorId(int id) => _repo.ObtenerPorId(id);
    }
}

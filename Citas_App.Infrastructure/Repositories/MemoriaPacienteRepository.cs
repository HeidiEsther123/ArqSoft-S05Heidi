using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;

namespace Citas_App.Infrastructure.Repositories
{
    public class MemoriaPacienteRepository : IPacienteRepository
    {
        private readonly List<Paciente> _pacientes = new()
        {
            new Paciente { Id = 1, Nombre = "Ana", Apellido = "García", Email = "ana@email.com", Telefono = "999-0001" },
            new Paciente { Id = 2, Nombre = "Luis", Apellido = "Martínez", Email = "luis@email.com", Telefono = "999-0002" },
            new Paciente { Id = 3, Nombre = "María", Apellido = "López", Email = "maria@email.com", Telefono = "999-0003" }
        };

        public List<Paciente> ObtenerTodos() => _pacientes;

        public Paciente? ObtenerPorId(int id) =>
            _pacientes.FirstOrDefault(p => p.Id == id);

        public void Agregar(Paciente paciente)
        {
            paciente.Id = _pacientes.Count > 0 ? _pacientes.Max(p => p.Id) + 1 : 1;
            _pacientes.Add(paciente);
        }
    }
}
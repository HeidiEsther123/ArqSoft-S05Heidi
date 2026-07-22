using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;

namespace Citas_App.Tests.Fakes
{
    // ---------------------------------------------------------------------
    // Adapters "fake" en memoria — mismos Ports que usa el proyecto real,
    // pero con datos controlados para la prueba. No es una librería de
    // mocks: son clases reales que implementan las interfaces del Domain.
    // ---------------------------------------------------------------------

    public class CitaRepositoryFake : ICitaRepository
    {
        private readonly List<Cita> _citas;
        public CitaRepositoryFake(List<Cita> citas) => _citas = citas;

        public List<Cita> ObtenerTodos() => _citas;
        public List<Cita> ObtenerPorPaciente(int pacienteId)
            => _citas.Where(c => c.PacienteId == pacienteId).ToList();
    }

    public class MedicoRepositoryFake : IMedicoRepository
    {
        private readonly List<Medico> _medicos;
        public MedicoRepositoryFake(List<Medico> medicos) => _medicos = medicos;

        public List<Medico> ObtenerTodos() => _medicos;
        public Medico? ObtenerPorId(int id) => _medicos.FirstOrDefault(m => m.Id == id);
    }

    public class PacienteRepositoryFake : IPacienteRepository
    {
        private readonly List<Paciente> _pacientes;
        public PacienteRepositoryFake(List<Paciente> pacientes) => _pacientes = pacientes;

        public List<Paciente> ObtenerTodos() => _pacientes;
        public Paciente? ObtenerPorId(int id) => _pacientes.FirstOrDefault(p => p.Id == id);
        public void Agregar(Paciente paciente) => _pacientes.Add(paciente);
    }
}

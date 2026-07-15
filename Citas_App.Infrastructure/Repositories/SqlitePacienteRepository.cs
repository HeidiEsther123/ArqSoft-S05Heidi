using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;
using Microsoft.Data.Sqlite;

namespace Citas_App.Infrastructure.Repositories
{
    public class SqlitePacienteRepository : IPacienteRepository
    {
        // 💡 Refactorización: Ahora dependemos del contexto inyectado
        private readonly SqliteDbContext _context;

        public SqlitePacienteRepository(SqliteDbContext context)
        {
            _context = context;
        }

        private static Paciente LeerFila(SqliteDataReader r) => new Paciente
        {
            Id = r.GetInt32(0),
            Nombre = r.GetString(1),
            Apellido = r.GetString(2),
            Email = r.IsDBNull(3) ? string.Empty : r.GetString(3),
            Telefono = r.IsDBNull(4) ? string.Empty : r.GetString(4)
        };

        // ── Port ────────────────────────────────────────────────────────────────

        public List<Paciente> ObtenerTodos()
        {
            using var conn = _context.CrearConexion();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Nombre, Apellido, Email, Telefono FROM Pacientes;";

            var lista = new List<Paciente>();
            using var r = cmd.ExecuteReader();
            while (r.Read()) lista.Add(LeerFila(r));
            return lista;
        }

        public Paciente? ObtenerPorId(int id)
        {
            using var conn = _context.CrearConexion();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Nombre, Apellido, Email, Telefono FROM Pacientes WHERE Id = $id;";
            cmd.Parameters.AddWithValue("$id", id);

            using var r = cmd.ExecuteReader();
            return r.Read() ? LeerFila(r) : null;
        }

        public void Agregar(Paciente paciente)
        {
            using var conn = _context.CrearConexion();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Pacientes (Nombre, Apellido, Email, Telefono)
                VALUES ($nombre, $apellido, $email, $telefono);";
            cmd.Parameters.AddWithValue("$nombre", paciente.Nombre);
            cmd.Parameters.AddWithValue("$apellido", paciente.Apellido);
            cmd.Parameters.AddWithValue("$email", paciente.Email);
            cmd.Parameters.AddWithValue("$telefono", paciente.Telefono);
            cmd.ExecuteNonQuery();
        }
    }
}
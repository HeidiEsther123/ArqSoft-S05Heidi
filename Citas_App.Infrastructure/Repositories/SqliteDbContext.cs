using Microsoft.Data.Sqlite;
using System.IO;

namespace Citas_App.Infrastructure.Repositories
{
    public class SqliteDbContext
    {
        private readonly string _connectionString;

        public SqliteDbContext(string dbPath)
        {
            _connectionString = $"Data Source={dbPath}";
            InicializarEsquema();
        }

        public SqliteConnection CrearConexion()
        {
            var conn = new SqliteConnection(_connectionString);
            conn.Open();
            return conn;
        }

        private void InicializarEsquema()
        {
            using var conn = CrearConexion();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Citas (
                    Id         INTEGER PRIMARY KEY AUTOINCREMENT,
                    PacienteId INTEGER NOT NULL,
                    MedicoId   INTEGER NOT NULL,
                    Fecha      TEXT    NOT NULL,   -- yyyy-MM-dd
                    Hora       TEXT    NOT NULL,   -- HH:mm
                    Motivo     TEXT,
                    Estado     TEXT    NOT NULL DEFAULT 'Pendiente'
                );";
            cmd.ExecuteNonQuery();
        }
    }
}
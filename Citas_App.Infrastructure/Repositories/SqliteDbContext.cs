using Microsoft.Data.Sqlite;

namespace Citas_App.Infrastructure.Repositories
{
    public class SqliteDbContext
    {
        private readonly string _connectionString;

        public SqliteDbContext(string dbPath)
        {
            _connectionString = $"Data Source={dbPath}";
            InicializarTablas();
        }

        public SqliteConnection CrearConexion()
        {
            var conn = new SqliteConnection(_connectionString);
            conn.Open();
            return conn;
        }

        private void InicializarTablas()
        {
            using var conn = CrearConexion();
            var cmd = conn.CreateCommand();

            // 💡 Agregamos la creación de ambas tablas de manera centralizada
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Citas (
                    Id         INTEGER PRIMARY KEY AUTOINCREMENT,
                    PacienteId INTEGER NOT NULL,
                    MedicoId   INTEGER NOT NULL,
                    Fecha      TEXT    NOT NULL,
                    Hora       TEXT    NOT NULL,
                    Motivo     TEXT,
                    Estado     TEXT    NOT NULL DEFAULT 'Pendiente'
                );
                
                CREATE TABLE IF NOT EXISTS Pacientes (
                    Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre   TEXT NOT NULL,
                    Apellido TEXT NOT NULL,
                    Email    TEXT,
                    Telefono TEXT
                );";
            cmd.ExecuteNonQuery();
        }
    }
}
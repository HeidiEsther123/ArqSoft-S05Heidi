using Citas_App.Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Citas_App.Infrastructure.Repositories
{
    public static class RepositoryFactory
    {
        // Método helper para obtener la ruta absoluta hacia el archivo .db en el directorio del entorno/API
        private static string ObtenerRutaDb(IWebHostEnvironment env)
        {
            return Path.Combine(env.ContentRootPath, "CitasApp.db");
        }

        public static IPacienteRepository CrearPacienteRepository(string entorno, IWebHostEnvironment env)
        {
            return entorno switch
            {
                "Sqlite" => new SqlitePacienteRepository(new SqliteDbContext(ObtenerRutaDb(env))),
                "Production" => new MemoriaPacienteRepository(),
                _ => new JsonPacienteRepository(env)
            };
        }

        public static IMedicoRepository CrearMedicoRepository(string entorno, IWebHostEnvironment env)
        {
            return entorno switch
            {
                "Sqlite" => new SqliteMedicoRepository(ObtenerRutaDb(env)),
                "Production" => new JsonMedicoRepository(env),
                _ => new JsonMedicoRepository(env)
            };
        }
        public static ICitaRepository CrearCitaRepository(string entorno, IWebHostEnvironment env)
        {
            return entorno switch
            {
                // 💡 Instanciamos el contexto pasándole la ruta string, y luego se lo inyectamos al repositorio
                "Sqlite" => new SqliteCitaRepository(new SqliteDbContext(ObtenerRutaDb(env))),
                "Production" => new JsonCitaRepository(env),
                _ => new JsonCitaRepository(env)
            };
        }
    }
}
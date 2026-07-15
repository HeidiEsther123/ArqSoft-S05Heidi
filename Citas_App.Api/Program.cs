using Citas_App.Application.Services;
using Citas_App.Domain.Interfaces;
using Citas_App.Infrastructure.Repositories;

namespace Citas_App.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Swagger configurado
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // 1. Forzamos el entorno de persistencia a "Sqlite" 
            // (O puedes dejar builder.Environment.EnvironmentName si cambias el switch de la factory a "Development")
            string entornoPersistencia = "Sqlite";

            // 2. Registro de PacienteRepository manteniendo tu decorador de Logging
            builder.Services.AddScoped<IPacienteRepository>(sp =>
            {
                var env = sp.GetRequiredService<IWebHostEnvironment>();
                var repo = RepositoryFactory.CrearPacienteRepository(entornoPersistencia, env);
                return new LogginPacienteRepository(repo);
            });

            // 3. Cambiamos los repositorios fijos de JSON a la Factoría usando SQLite
            builder.Services.AddScoped<IMedicoRepository>(sp =>
            {
                var env = sp.GetRequiredService<IWebHostEnvironment>();
                return RepositoryFactory.CrearMedicoRepository(entornoPersistencia, env);
            });

            builder.Services.AddScoped<ICitaRepository>(sp =>
            {
                var env = sp.GetRequiredService<IWebHostEnvironment>();
                return RepositoryFactory.CrearCitaRepository(entornoPersistencia, env);
            });

            // Servicios de Aplicación
            builder.Services.AddScoped<PacienteService>();
            builder.Services.AddScoped<MedicoService>();
            builder.Services.AddScoped<CitaService>();

            var app = builder.Build();

            // Activar Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Citas V1");
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
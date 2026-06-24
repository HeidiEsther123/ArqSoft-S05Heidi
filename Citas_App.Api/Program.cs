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

            builder.Services.AddScoped<IPacienteRepository>(sp =>
            {
                var env = sp.GetRequiredService<IWebHostEnvironment>();
                var repo = RepositoryFactory.CrearPacienteRepository(builder.Environment.EnvironmentName, env);
                return new LogginPacienteRepository(repo);
            });

            builder.Services.AddScoped<IMedicoRepository, JsonMedicoRepository>();
            builder.Services.AddScoped<ICitaRepository, JsonCitaRepository>();
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
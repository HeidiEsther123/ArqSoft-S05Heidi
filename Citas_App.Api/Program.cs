using Citas_App.Application.Services;
using Citas_App.Domain.Interfaces;
using Citas_App.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IPacienteRepository>(sp =>
{
  
    var env = sp.GetRequiredService<IWebHostEnvironment>();

    var repo = RepositoryFactory.CrearPacienteRepository(builder.Environment.EnvironmentName, env);

    return new LoggingPacienteRepository(repo);
});

builder.Services.AddScoped<IMedicoRepository, JsonMedicoRepository>();
builder.Services.AddScoped<ICitaRepository, JsonCitaRepository>();

builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<CitaService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
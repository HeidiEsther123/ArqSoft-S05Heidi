using Citas_App.Application.Services;
using Citas_App.Domain.Interfaces;
using Citas_App.Infrastructure.Repositories;
using SQLitePCL;

SQLitePCL.Batteries.Init();

var builder = WebApplication.CreateBuilder(args);

// ── 1. Carpeta de datos ───────────────────────────────────────────────────────
var dataFolder = Path.Combine(builder.Environment.ContentRootPath, "..", "Citas_App.Api", "data");
Directory.CreateDirectory(dataFolder);

// Rutas para CSV
var csvPacientes = Path.Combine(dataFolder, "pacientes.csv");
var csvMedicos = Path.Combine(dataFolder, "medicos.csv");
var csvCitas = Path.Combine(dataFolder, "citas.csv");

// Ruta para SQLite
var sqlitePath = Path.Combine(dataFolder, "citasapp.db");

// ── 2. Elige tus Adapters ─────────────────────────────────────────────────────

// ▶ Bloque A — JSON
/*
builder.Services.AddSingleton<IPacienteRepository, JsonPacienteRepository>();
builder.Services.AddSingleton<IMedicoRepository,   JsonMedicoRepository>();
builder.Services.AddSingleton<ICitaRepository,     JsonCitaRepository>();
*/

// ▶ Bloque B — CSV
/*
builder.Services.AddSingleton<IPacienteRepository>(_ => new CsvPacienteRepository(csvPacientes));
builder.Services.AddSingleton<IMedicoRepository>  (_ => new CsvMedicoRepository(csvMedicos));
builder.Services.AddSingleton<ICitaRepository>    (_ => new CsvCitaRepository(csvCitas));
*/

// ▶ Bloque C — SQLite  ← ¡ACTIVO Y REFACTORIZADO!
var dbContext = new SqliteDbContext(sqlitePath);
builder.Services.AddSingleton(dbContext); // Registrar el contexto en el contenedor

// 💡 Paciente y Médico se quedan con la ruta directa en string para que no den error
builder.Services.AddSingleton<IPacienteRepository>(_ => new SqlitePacienteRepository(sqlitePath));
builder.Services.AddSingleton<IMedicoRepository>(_ => new SqliteMedicoRepository(sqlitePath));

// 💡 Solo Cita se desacopla inyectando el DbContext para tu tarea
builder.Services.AddSingleton<ICitaRepository>(sp => new SqliteCitaRepository(sp.GetRequiredService<SqliteDbContext>()));


// ── 3. Servicios de aplicación ───────────────────────────────────────────────
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<CitaService>();

// ── 4. Sesiones ───────────────────────────────────────────────────────────────
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ── 5. MVC ────────────────────────────────────────────────────────────────────
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

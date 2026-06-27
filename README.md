### Universidad: Tecnologico de Software
### Materia: Arquitectura de Software
### Maestro: Jorge Javier Pedroza Romero
### Alumno: Heidi Esther Peña Betanzos
### Grado: 3B
## ADR — Estilo Arquitectónico
# Citas_App - Sistema de Gestión de Citas Médicas

## 🏥 Descripción del Proyecto

Citas_App es una aplicación web desarrollada con ASP.NET Core MVC para optimizar la administración de una clínica médica. Permite gestionar catálogos de Pacientes y Médicos, así como la programación de Citas.

El proyecto fue refactorizado a **Arquitectura Hexagonal (Ports & Adapters)** dividido en 4 proyectos separados, lo que permite intercambiar la tecnología de almacenamiento sin tocar la lógica de negocio.

---

## 🛠️ Tecnologías Utilizadas

| Componente | Tecnología |
|---|---|
| Framework Backend | .NET 10 / ASP.NET Core |
| Lenguaje | C# |
| Frontend | Razor Views, HTML5, CSS, Bootstrap |
| Persistencia | JSON, CSV, SQLite, Memoria |
| Entorno de Desarrollo | Visual Studio |

---

## 🏗️ Arquitectura Hexagonal
itas_App.sln

├── Citas_App.Domain/         ← Modelos e Interfaces (Ports)

│   ├── Models/

│   │   ├── Paciente.cs

│   │   ├── Medico.cs

│   │   └── Cita.cs

│   └── Interfaces/

│       ├── IPacienteRepository.cs

│       ├── IMedicoRepository.cs

│       └── ICitaRepository.cs

├── Citas_App.Application/    ← Servicios de aplicación

│   └── Services/

│       ├── PacienteService.cs

│       ├── MedicoService.cs

│       └── CitaService.cs

├── Citas_App.Infrastructure/ ← Adapters de salida

│   └── Repositories/

│       ├── JsonPacienteRepository.cs

│       ├── JsonMedicoRepository.cs

│       ├── JsonCitaRepository.cs

│       ├── CsvPacienteRepository.cs

│       ├── CsvMedicoRepository.cs

│       ├── CsvCitaRepository.cs

│       ├── SqlitePacienteRepository.cs

│       ├── SqliteMedicoRepository.cs

│       ├── SqliteCitaRepository.cs

│       └── MemoriaPacienteRepository.cs

└── Citas_App/                ← Adapter de entrada (Web)

├── Controllers/

├── Views/

└── Program.cs
---

## 🔌 Cambiar de Adapter

En `Program.cs` solo descomenta el bloque que quieras usar:

```csharp
// ▶ Bloque A — JSON
builder.Services.AddSingleton<IPacienteRepository, JsonPacienteRepository>();
builder.Services.AddSingleton<IMedicoRepository,   JsonMedicoRepository>();
builder.Services.AddSingleton<ICitaRepository,     JsonCitaRepository>();

// ▶ Bloque B — CSV
builder.Services.AddSingleton<IPacienteRepository>(_ => new CsvPacienteRepository(csvPacientes));
builder.Services.AddSingleton<IMedicoRepository>  (_ => new CsvMedicoRepository(csvMedicos));
builder.Services.AddSingleton<ICitaRepository>    (_ => new CsvCitaRepository(csvCitas));

// ▶ Bloque C — SQLite
builder.Services.AddSingleton<IPacienteRepository>(_ => new SqlitePacienteRepository(sqlitePath));
builder.Services.AddSingleton<IMedicoRepository>  (_ => new SqliteMedicoRepository(sqlitePath));
builder.Services.AddSingleton<ICitaRepository>    (_ => new SqliteCitaRepository(sqlitePath));
```

El Domain y los Controllers **nunca cambian** — solo este archivo.

---

## 📸 Capturas de Pantalla

<img width="1918" height="1078" alt="Captura de pantalla 2026-06-26 202717" src="https://github.com/user-attachments/assets/847ab35e-2fce-4239-95dc-5f6574211417" />
<img width="1918" height="1078" alt="Captura de pantalla 2026-06-26 202702" src="https://github.com/user-attachments/assets/dc05b158-305f-4ff9-b17e-9b864a9e7f0d" />
<img width="1918" height="1078" alt="Captura de pantalla 2026-06-26 202629" src="https://github.com/user-attachments/assets/1bfb7f8e-08fa-4e98-8afd-d3416737c8f0" />

---

## 🤖 Uso de IA

Heidi Esther Peña Betanzos utilizó IA para resolver errores de compilación relacionados con namespaces inconsistentes y referencias entre proyectos que las herramientas automáticas de Visual Studio no lograban corregir.

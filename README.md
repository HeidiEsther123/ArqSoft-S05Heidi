### Universidad: Tecnologico de Software
### Materia: Arquitectura de Software
### Maestro: Jorge Javier Pedroza Romero
### Alumno: Heidi Esther Peña Betanzos
### Grado: 3B

Aplicación web para la gestión de citas médicas, construida con **ASP.NET Core MVC**, siguiendo una **Arquitectura Hexagonal (Puertos y Adaptadores)** e incorporando pruebas unitarias e integración continua.

---

## 🏥 ¿Qué es CitasApp?

CitasApp es una herramienta para gestionar citas médicas de una clínica. Permite administrar pacientes, médicos y las citas entre ellos, con soporte para múltiples formas de almacenamiento de datos:

- 🧑‍⚕️ **Médicos** — registro y consulta de médicos disponibles
- 🧑 **Pacientes** — registro y consulta de pacientes
- 📅 **Citas** — programación y seguimiento de citas entre pacientes y médicos

---

## Requisitos previos

- [.NET 9 SDK](https://dotnet.microsoft.com/download) (o la versión indicada en el `.slnx`)
- Visual Studio 2022/2026 o VS Code

---

## Cómo correrlo

1. Clona el repositorio:
   ```bash
   git clone https://github.com/HeidiEsther123/CitasApp.git
   cd CitasApp
   ```

2. Restaura los paquetes NuGet:
   ```bash
   dotnet restore
   ```

3. Corre el proyecto:
   ```bash
   dotnet run --project Citas_App
   ```

4. Abre el navegador en la URL que indique la consola para ver la interfaz web.

---

## Estructura del proyecto

```
Citas_App/
├── Citas_App/                    # Proyecto web (Controllers, Views, Program.cs)
├── Citas_App.Api/                # API
├── Citas_App.Application/        # Casos de uso / Servicios de aplicación
│   └── Services/                 # CitaService, MedicoService, PacienteService
├── Citas_App.Domain/              # Núcleo del negocio (Hexágono)
│   ├── Interfaces/                # Puertos (ICitaRepository, IMedicoRepository, IPacienteRepository)
│   └── Models/                    # Cita, Medico, Paciente
├── Citas_App.Infrastructure/      # Adaptadores de salida
│   └── Repositories/              # JSON, SQLite, CSV, memoria
├── Citas_App.Tests/               # Suite de pruebas xUnit
│   ├── Fakes/                     # Repositorios fake en memoria para pruebas
│   └── Services/                  # Pruebas de CitaService, MedicoService, PacienteService
└── .github/workflows/             # Pipeline de GitHub Actions (CI)
```

---

## ADR — Estilo Arquitectónico

### 👀 Contexto 👀
CitasApp es una app web para gestionar citas médicas. Maneja pacientes, médicos y citas. Actualmente solo tiene interfaz web y guarda datos en JSON, pero podría crecer: app móvil, notificaciones, base de datos real.

### ☕ Decisión ☕
Elegí Arquitectura Hexagonal dividida en tres proyectos: Domain, Infrastructure y Web. Lo hice porque si en el futuro necesito cambiar el almacenamiento de JSON a SQL, o agregar una API para una app móvil, solo cambio el Adapter sin tocar la lógica del negocio.

### ✅☕ Consecuencias Positivas ☕✅
- Si lo llegara a cambiar el JSON a base de datos, solo creo un nuevo repositorio. Los controllers y modelos no se tocan.
- Si agrego una app móvil, solo agrego un nuevo Adapter de entrada.

### ☕❌ Consecuencias Negativas ❌☕
- Configurar tres proyectos con sus referencias y namespaces fue más complicado que tener todo en uno.
- Para un sistema tan pequeño, quizás capas simples hubiera sido suficiente.

---
## Pruebas unitarias e Integración Continua

### 🧪 Pruebas — `Citas_App.Tests/`
Suite de pruebas con **xUnit**, cubriendo:

- **`CitaService`** — obtención de todas las citas y filtrado por paciente.
- **`MedicoService`** — obtención de médicos y búsqueda por Id (incluyendo el caso de Id inexistente).
- **`PacienteService`** — obtención de pacientes, búsqueda por Id, y registro de nuevos pacientes.

Las pruebas usan repositorios fake en memoria (`CitaRepositoryFake`, `MedicoRepositoryFake`, `PacienteRepositoryFake`) que implementan los mismos Puertos (`ICitaRepository`, etc.) que usa el proyecto real, en lugar de depender de JSON o SQLite durante las pruebas.

Para correrlas localmente:
```bash
dotnet test Citas_App.slnx
```

### ⚙️ Integración Continua — `.github/workflows/ci.yml`
Cada `push` y Pull Request dispara un workflow de GitHub Actions que:

1. Restaura los paquetes NuGet
2. Compila la solución completa
3. Corre la suite de pruebas xUnit

El resultado (✅ o ❌) aparece como check en cada Pull Request.

**Evidencia del pipeline funcionando:**

<img width="1918" height="1015" alt="Captura de pantalla 2026-07-21 220935" src="https://github.com/user-attachments/assets/3418216c-c3c1-48c7-8853-1bb6edb588a1" />

---

## Uso de IA

Yo Heidi Esther Peña Betanzos usé IA para corregir errores de referencias entre proyectos que Visual Studio no me resolvía automáticamente y para configurar el pipeline de GitHub Actions.

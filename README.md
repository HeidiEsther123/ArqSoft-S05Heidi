### Universidad: Tecnologico de Software
### Materia: Arquitectura de Software
### Maestro: Jorge Javier Pedroza Romero
### Alumno: Heidi Esther Peña Betanzos
### Grado: 3B
## ADR — Estilo Arquitectónico

# 🏥 CitasApp — Sistema de Gestión de Citas Médicas

## 📝 Descripción del Proyecto
**CitasApp** es una aplicación web desarrollada en **.NET 8** diseñada para optimizar y gestionar el flujo de citas médicas en clínicas o consultorios. Permite administrar de forma integral la información de **Pacientes**, **Médicos** y las **Citas** agendadas. 
---

## 🏗️ Estructura y Estilo Arquitectónico
El sistema implementa una **Arquitectura Hexagonal (Puertos y Adaptadores)**, lo que garantiza una separación total entre las reglas de negocio y los detalles tecnológicos (como bases de datos o interfaces de usuario). 

La solución está dividida en los siguientes proyectos:
* **`Citas_App.Domain` (Núcleo):** Contiene los modelos de negocio (`Cita`, `Paciente`, `Medico`, `Usuario`) y las interfaces o contratos (*Puertos*). No tiene dependencias de librerías externas ni de infraestructura.
* **`Citas_App.Application`:** Orquesta los casos de uso del sistema a través de servicios (`CitaService`, `PacienteService`, etc.).
* **`Citas_App.Infrastructure` (Adaptadores de Salida):** Implementa el acceso físico a los datos. Inicialmente soportaba almacenamiento en archivos JSON y CSV, pero fue refactorizada con un manejador centralizado (`SqliteDbContext`) para persistir datos en **SQLite**.
* **`Citas_App` / `Citas_App.Api` (Adaptadores de Entrada):** La interfaz gráfica web construida bajo el patrón **ASP.NET Core MVC** y los controladores que exponen los flujos al navegador.

---

## 🛡️ Nuevas Características Añadidas
1. **Sistema de Autenticación (Login):** Se implementó un flujo de seguridad en capas para validar el acceso al sistema, utilizando `HttpContext.Session` para mantener y proteger las sesiones de usuario activas durante la navegación.
2. **Refactorización de Infraestructura (Mitigación de Code Smells):** * **Extract Class:** Se extrajo la lógica de conexiones e inicialización física de tablas a la clase especializada `SqliteDbContext`.
   * **Dependency Injection:** Se inyectó de manera centralizada el contexto en los repositorios (`SqliteCitaRepository`, `SqlitePacienteRepository`), eliminando el acoplamiento fuerte (*Tight Coupling*) que generaba tener `new SqliteConnection()` repetido en cada adaptador.

---

## 🛠️ Tecnologías Usadas
* **Lenguaje:** C# 12
* **Framework Principal:** .NET 8 / ASP.NET Core MVC
* **Motor de Base de Datos:** SQLite (vía `Microsoft.Data.Sqlite` y `SQLitePCL`)
* **Gestión de Estado:** Distributed Memory Cache & Sessions para el módulo de Login.
* **IDE:** Visual Studio 2022
* **Control de Versiones:** Git

---
## 📸 Capturas de Pantalla de la Aplicación
##### loggin 
<img width="1910" height="1020" alt="Captura de pantalla 2026-07-15 111152" src="https://github.com/user-attachments/assets/d62f2e87-06aa-4bf9-a413-e4c7246a900f" />

##### nuevo codigo implementado 'SqliteDbContext' 
<img width="1380" height="783" alt="Captura de pantalla 2026-07-15 111219" src="https://github.com/user-attachments/assets/9d90a837-3748-4f45-ab2e-f5f77aeb2dbe" />

---
## Uso de IA 
Yo Heidi Esther Peña Betanzos usé IA para corregir errores de referencias entre proyectos que Visual Studio no me resolvía automáticamente.

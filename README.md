### Universidad: Tecnologico de Software
### Materia: Arquitectura de Software
### Maestro: Jorge Javier Pedroza Romero
### Alumno: Heidi Esther Peña Betanzos
### Grado: 3B
## ADR — Estilo Arquitectónico

#  🏥 CitasApp 🏥

## 👀 Contexto 👀
CitasApp es una app web para gestionar citas médicas. Maneja pacientes, médicos y citas. Actualmente solo tiene interfaz web y guarda datos en JSON, pero podría crecer: app móvil, notificaciones, base de datos real.

## ☕ Decisión ☕
Elegí Arquitectura Hexagonal dividida en tres proyectos: Domain, Infrastructure y Web. Lo hice porque si en el futuro necesito cambiar el almacenamiento de JSON a SQL, o agregar una API para una app móvil, solo cambio el Adapter sin tocar la lógica del negocio.

## ✅☕Consecuencias Positivas ☕✅

Si lo llegara a cambiar el JSON a base de datos, solo creo un nuevo repositorio. Los controllers y modelos no se tocan.
Si agrego una app móvil, solo agrego un nuevo Adapter de entrada.

## ☕❌ Consecuencias Negativas ❌☕

Configurar tres proyectos con sus referencias y namespaces fue más complicado que tener todo en uno.
Para un sistema tan pequeño, quizás capas simples hubiera sido suficiente.

## Uso de IA 
Yo Heidi Esther Peña Betanzos usé IA para corregir errores de referencias entre proyectos que Visual Studio no me resolvía automáticamente.

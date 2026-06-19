### Universidad: Tecnologico de Software
### Materia: Arquitectura de Software
### Maestro: Jorge Javier Pedroza Romero
### Alumno: Heidi Esther Peña Betanzos
### Grado: 3B
## ADR — Estilo Arquitectónico

# 🏥 ADR — Estilo Arquitectónico para CitasApp 🏥

## 👀 Contexto 👀
CitasApp es una aplicación web diseñada para gestionar citas médicas, permitiendo administrar pacientes, médicos y las citas entre ellos. Además, el proyecto incluye una API adicional de Calculadora, utilizada como módulo de práctica para probar controladores, rutas y estructura de la solución.

Actualmente, la app funciona únicamente como una interfaz web y almacena la información en archivos JSON. Sin embargo, el sistema tiene potencial de crecimiento: podría requerir una app móvil, notificaciones, integración con servicios externos o migración hacia una base de datos real.

Este posible crecimiento motivó la necesidad de elegir un estilo arquitectónico que permita extender el sistema sin reescribir la lógica del negocio.

## ☕ Decisión ☕
Elegí implementar Arquitectura Hexagonal (Ports & Adapters), dividiendo el proyecto en tres capas o proyectos independientes:

Domain: contiene las reglas del negocio, entidades y lógica central.

Infrastructure: implementa los adaptadores de salida, como el repositorio basado en JSON.

Web: expone los controladores y endpoints de la API.

Esta arquitectura permite que cada módulo —Calculadora, Pacientes, Médicos y Citas— funcione como un conjunto de casos de uso independientes, conectados mediante puertos y adaptadores. Si en el futuro necesito reemplazar JSON por SQL Server, o agregar una API para una app móvil, solo debo crear nuevos adaptadores sin tocar el dominio.

## ☕📦 Módulos incluidos en la API 📦☕
🔢 1. Calculadora
Un módulo simple para practicar controladores, rutas y pruebas de API. Incluye operaciones básicas como suma, resta, multiplicación y división.

## 🧑‍⚕️ 2. Pacientes
Permite registrar, consultar, actualizar y eliminar pacientes.
Incluye validaciones básicas y almacenamiento en JSON.

## 👨‍⚕️ 3. Médicos
Administra médicos, especialidades y datos generales.
Se integra con el módulo de citas.

## 📅 4. Citas
Gestiona la relación entre pacientes y médicos.
Incluye fecha, hora, motivo y estado de la cita (Pendiente, Confirmada, Cancelada).

Cada módulo está desacoplado gracias a la Arquitectura Hexagonal.

## ☕✅ Consecuencias Positivas ☕✅
Si cambio el almacenamiento de JSON a SQL, solo creo un nuevo repositorio.

Los controladores y modelos del dominio no se ven afectados por cambios tecnológicos.

Si agrego una app móvil, solo creo un nuevo adaptador de entrada.

La API puede crecer por módulos sin romper los existentes.

La arquitectura favorece pruebas unitarias y mantenimiento.

## ☕❌ Consecuencias Negativas ❌☕
Configurar tres proyectos con sus referencias y namespaces fue más complejo que tener todo en uno.

Para un sistema pequeño, una arquitectura por capas tradicional pudo haber sido suficiente.

Requiere más disciplina y estructura desde el inicio.

## 🏥 ADR — Estilo Arquitectónico para CitasApp 🏥
👀 Contexto 👀
CitasApp es una aplicación web diseñada para gestionar citas médicas, permitiendo administrar pacientes, médicos y las citas entre ellos. Además, el proyecto incluye una API adicional de Calculadora, utilizada como módulo de práctica para probar controladores, rutas y estructura de la solución.

Actualmente, la app funciona únicamente como una interfaz web y almacena la información en archivos JSON. Sin embargo, el sistema tiene potencial de crecimiento: podría requerir una app móvil, notificaciones, integración con servicios externos o migración hacia una base de datos real.

Este posible crecimiento motivó la necesidad de elegir un estilo arquitectónico que permita extender el sistema sin reescribir la lógica del negocio.

☕ Decisión ☕
Elegí implementar Arquitectura Hexagonal (Ports & Adapters), dividiendo el proyecto en tres capas o proyectos independientes:

Domain: contiene las reglas del negocio, entidades y lógica central.

Infrastructure: implementa los adaptadores de salida, como el repositorio basado en JSON.

Web: expone los controladores y endpoints de la API.

Esta arquitectura permite que cada módulo —Calculadora, Pacientes, Médicos y Citas— funcione como un conjunto de casos de uso independientes, conectados mediante puertos y adaptadores. Si en el futuro necesito reemplazar JSON por SQL Server, o agregar una API para una app móvil, solo debo crear nuevos adaptadores sin tocar el dominio.

☕📦 Módulos incluidos en la API 📦☕
🔢 1. Calculadora
Un módulo simple para practicar controladores, rutas y pruebas de API. Incluye operaciones básicas como suma, resta, multiplicación y división.

🧑‍⚕️ 2. Pacientes
Permite registrar, consultar, actualizar y eliminar pacientes.
Incluye validaciones básicas y almacenamiento en JSON.

👨‍⚕️ 3. Médicos
Administra médicos, especialidades y datos generales.
Se integra con el módulo de citas.

📅 4. Citas
Gestiona la relación entre pacientes y médicos.
Incluye fecha, hora, motivo y estado de la cita (Pendiente, Confirmada, Cancelada).

Cada módulo está desacoplado gracias a la Arquitectura Hexagonal.

☕✅ Consecuencias Positivas ☕✅
Si cambio el almacenamiento de JSON a SQL, solo creo un nuevo repositorio.

Los controladores y modelos del dominio no se ven afectados por cambios tecnológicos.

Si agrego una app móvil, solo creo un nuevo adaptador de entrada.

La API puede crecer por módulos sin romper los existentes.

La arquitectura favorece pruebas unitarias y mantenimiento.

☕❌ Consecuencias Negativas ❌☕
Configurar tres proyectos con sus referencias y namespaces fue más complejo que tener todo en uno.

Para un sistema pequeño, una arquitectura por capas tradicional pudo haber sido suficiente.

Requiere más disciplina y estructura desde el inicio.

# 📸 capturas 
<img width="1918" height="1078" alt="Captura de pantalla 2026-06-16 200015" src="https://github.com/user-attachments/assets/aed4f2ba-9799-4041-abcf-9b4aa85ff742" />
<img width="1915" height="1075" alt="Captura de pantalla 2026-06-16 172554" src="https://github.com/user-attachments/assets/6e9748f9-0f91-4cdc-bdef-29648716a7a7" />
<img width="1918" height="1078" alt="Captura de pantalla 2026-06-16 172738" src="https://github.com/user-attachments/assets/598763f2-dc2f-4cdf-a0d1-905634796687" />
<img width="1918" height="1078" alt="Captura de pantalla 2026-06-16 195620" src="https://github.com/user-attachments/assets/6291d07c-1948-4519-bfbb-269984f7c3d3" />
<img width="1918" height="1078" alt="Captura de pantalla 2026-06-16 195650" src="https://github.com/user-attachments/assets/d1966a11-45bd-45c2-aa42-8a8e7fad0563" />



##🤖 Uso de IA
Yo, Heidi Esther Peña Betanzos, utilicé IA  para corregir errores importantes entre proyectos que Visual Studio no lo poadia hacer commit y aun estoy batallando en eso.

using Citas_App.Application.Services;
using Citas_App.Domain.Models;
using Citas_App.Tests.Fakes;
using Xunit;

namespace Citas_App.Tests.Services
{
    public class PacienteServiceTests
    {
        private List<Paciente> CrearPacientesDePrueba() => new()
        {
            new Paciente { Id = 1, Nombre = "Marta", Apellido = "Gómez", Email = "marta@correo.com", Telefono = "9991234567" },
            new Paciente { Id = 2, Nombre = "Iván", Apellido = "López", Email = "ivan@correo.com", Telefono = "9997654321" }
        };

        [Fact]
        public void ObtenerTodos_RegresaTodosLosPacientesDelRepositorio()
        {
            // Arrange
            var pacientes = CrearPacientesDePrueba();
            var service = new PacienteService(new PacienteRepositoryFake(pacientes));

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.Equal(2, resultado.Count);
        }

        [Fact]
        public void ObtenerPorId_ConIdExistente_RegresaElPacienteCorrecto()
        {
            // Arrange
            var pacientes = CrearPacientesDePrueba();
            var service = new PacienteService(new PacienteRepositoryFake(pacientes));

            // Act
            var resultado = service.ObtenerPorId(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("marta@correo.com", resultado!.Email);
        }

        [Fact]
        public void Agregar_ConPacienteNuevo_LoAgregaAlRepositorio()
        {
            // Arrange
            var pacientes = CrearPacientesDePrueba();
            var service = new PacienteService(new PacienteRepositoryFake(pacientes));
            var nuevo = new Paciente { Id = 3, Nombre = "Sofía", Apellido = "Torres", Email = "sofia@correo.com", Telefono = "9990001111" };

            // Act
            service.Agregar(nuevo);
            var todos = service.ObtenerTodos();

            // Assert
            Assert.Equal(3, todos.Count);
            Assert.Contains(todos, p => p.Email == "sofia@correo.com");
        }
    }
}

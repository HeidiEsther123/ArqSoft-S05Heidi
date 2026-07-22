using Citas_App.Application.Services;
using Citas_App.Domain.Models;
using Citas_App.Tests.Fakes;
using Xunit;

namespace Citas_App.Tests.Services
{
    public class CitaServiceTests
    {
        private List<Cita> CrearCitasDePrueba() => new()
        {
            new Cita { Id = 1, PacienteId = 10, MedicoId = 1, Estado = "Pendiente" },
            new Cita { Id = 2, PacienteId = 20, MedicoId = 1, Estado = "Confirmada" },
            new Cita { Id = 3, PacienteId = 10, MedicoId = 2, Estado = "Pendiente" }
        };

        [Fact]
        public void ObtenerTodos_RegresaTodasLasCitasDelRepositorio()
        {
            // Arrange
            var citas = CrearCitasDePrueba();
            var service = new CitaService(new CitaRepositoryFake(citas));

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.Equal(3, resultado.Count);
            Assert.Equal(citas, resultado);
        }

        [Fact]
        public void ObtenerPorPaciente_ConPacienteConVariasCitas_RegresaSoloLasSuyas()
        {
            // Arrange
            var citas = CrearCitasDePrueba();
            var service = new CitaService(new CitaRepositoryFake(citas));

            // Act
            var resultado = service.ObtenerPorPaciente(10);

            // Assert
            Assert.Equal(2, resultado.Count);
            Assert.All(resultado, c => Assert.Equal(10, c.PacienteId));
        }

        [Fact]
        public void ObtenerPorPaciente_ConPacienteSinCitas_RegresaListaVacia()
        {
            // Arrange
            var citas = CrearCitasDePrueba();
            var service = new CitaService(new CitaRepositoryFake(citas));

            // Act
            var resultado = service.ObtenerPorPaciente(999);

            // Assert
            Assert.Empty(resultado);
        }
    }
}

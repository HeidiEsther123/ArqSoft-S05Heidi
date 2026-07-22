using Citas_App.Application.Services;
using Citas_App.Domain.Models;
using Citas_App.Tests.Fakes;
using Xunit;

namespace Citas_App.Tests.Services
{
    public class MedicoServiceTests
    {
        private List<Medico> CrearMedicosDePrueba() => new()
        {
            new Medico { Id = 1, Nombre = "Ana", Apellido = "Ruiz", Especialidad = "Pediatría", NumeroLicencia = "L001" },
            new Medico { Id = 2, Nombre = "Luis", Apellido = "Pérez", Especialidad = "Cardiología", NumeroLicencia = "L002" }
        };

        [Fact]
        public void ObtenerTodos_RegresaTodosLosMedicosDelRepositorio()
        {
            // Arrange
            var medicos = CrearMedicosDePrueba();
            var service = new MedicoService(new MedicoRepositoryFake(medicos));

            // Act
            var resultado = service.ObtenerTodos();

            // Assert
            Assert.Equal(2, resultado.Count);
        }

        [Fact]
        public void ObtenerPorId_ConIdExistente_RegresaElMedicoCorrecto()
        {
            // Arrange
            var medicos = CrearMedicosDePrueba();
            var service = new MedicoService(new MedicoRepositoryFake(medicos));

            // Act
            var resultado = service.ObtenerPorId(2);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Luis", resultado!.Nombre);
        }

        [Fact]
        public void ObtenerPorId_ConIdInexistente_RegresaNull()
        {
            // Arrange
            var medicos = CrearMedicosDePrueba();
            var service = new MedicoService(new MedicoRepositoryFake(medicos));

            // Act
            var resultado = service.ObtenerPorId(999);

            // Assert
            Assert.Null(resultado);
        }
    }
}

using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;
using System;
using System.Collections.Generic;

namespace Citas_App.Infrastructure.Repositories
{
    public class LogginPacienteRepository : IPacienteRepository
    {
        private readonly IPacienteRepository _inner;

        public LogginPacienteRepository(IPacienteRepository inner)
        {
            _inner = inner;
        }

        public List<Paciente> ObtenerTodos()
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ObtenerTodos — inicio");
            var resultado = _inner.ObtenerTodos();
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ObtenerTodos — {resultado.Count} registros");
            return resultado;
        }

        public Paciente? ObtenerPorId(int id)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ObtenerPorId({id}) — inicio");
            var resultado = _inner.ObtenerPorId(id);
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ObtenerPorId({id}) — {(resultado != null ? "encontrado" : "no encontrado")}");
            return resultado;
        }

        public void Agregar(Paciente paciente)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Agregar Paciente — inicio");
            _inner.Agregar(paciente);
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Agregar Paciente — completado con éxito");
        }
    }
}
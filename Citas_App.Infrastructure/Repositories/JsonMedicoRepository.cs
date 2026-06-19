using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace Citas_App.Infrastructure.Repositories
{
    public class JsonMedicoRepository : IMedicoRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public JsonMedicoRepository(IWebHostEnvironment env)
        {
            _path = Path.Combine(env.ContentRootPath, "data", "medicos.json");
        }

        public List<Medico> ObtenerTodos()
        {
            if (!File.Exists(_path)) return new();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Medico>>(json, _options) ?? new();
        }

        public Medico? ObtenerPorId(int id) =>
            ObtenerTodos().FirstOrDefault(m => m.Id == id);
    }
}
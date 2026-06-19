using Citas_App.Domain.Interfaces;
using Citas_App.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Citas_App.Infrastructure.Repositories
{
    public class JsonCitaRepository : ICitaRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            Converters =
            {
                new DateOnlyJsonConverter(),
                new TimeOnlyJsonConverter()
            }
        };

        public JsonCitaRepository(IWebHostEnvironment env)
        {
            _path = Path.Combine(env.ContentRootPath, "data", "citas.json");
        }

        public List<Cita> ObtenerTodos()
        {
            if (!File.Exists(_path)) return new();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Cita>>(json, _options) ?? new();
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId) =>
            ObtenerTodos().Where(c => c.PacienteId == pacienteId).ToList();
    }

    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
            => DateOnly.ParseExact(reader.GetString()!, "yyyy-MM-dd");

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }

    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        public override TimeOnly Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
            => TimeOnly.ParseExact(reader.GetString()!, "HH:mm");

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString("HH:mm"));
    }
}
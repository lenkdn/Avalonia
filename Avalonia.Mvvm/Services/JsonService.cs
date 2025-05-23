using System.IO;
using System.Text.Json;

namespace Avalonia.Mvvm.Services;

public class JsonService
{
    private readonly JsonSerializerOptions _options;

    public JsonService()
    {
        _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }

    public void Save<T>(T data, string fileName)
    {
        var json = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(fileName, json);
    }

    public T? Load<T>(string fileName)
    {
        if (!File.Exists(fileName)) return default;

        var json = File.ReadAllText(fileName);

        if (string.IsNullOrEmpty(json)) return default;

        return JsonSerializer.Deserialize<T>(json);
    }
}
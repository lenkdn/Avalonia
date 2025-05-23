namespace Avalonia.Mvvm.Models;

public record Item
{
    public string Name { get; set; } = string.Empty;
    public int Count { get; set; }
}
using System.Collections.Generic;
using Avalonia.Mvvm.Models;

namespace Avalonia.Mvvm.DTOs;

public class FirstDto
{
    public Item? SelectedItem { get; set; }
    public ICollection<Item> Items { get; set; } = [];
}
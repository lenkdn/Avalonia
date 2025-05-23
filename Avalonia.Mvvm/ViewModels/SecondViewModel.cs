using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Mvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Mvvm.ViewModels;

public partial class SecondViewModel : ViewModelBase
{
    [ObservableProperty] private Item? _selectedItem;

    public SecondViewModel()
    {
        Items.Add(new Item
        {
            Name = "Second item 1",
            Count = 21
        });

        Items.Add(new Item
        {
            Name = "Second item 2",
            Count = 22
        });
    }
    
    public SecondViewModel(
        Item? selectedItem,
        ICollection<Item> items)
    {
        SelectedItem = selectedItem;
        Items.Clear();
        foreach (var item in items) Items.Add(item);
    }

    public ObservableCollection<Item> Items { get; set; } = [];
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Mvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Mvvm.ViewModels;

public partial class FirstViewModel : ViewModelBase
{
    [ObservableProperty] private Item? _selectedItem;

    public FirstViewModel()
    {
        Items.Add(new Item
        {
            Name = "First item 1",
            Count = 11
        });

        Items.Add(new Item
        {
            Name = "First item 2",
            Count = 12
        });
    }

    public FirstViewModel(
        Item? selectedItem,
        ICollection<Item> items)
    {
        SelectedItem = selectedItem;
        Items.Clear();
        foreach (var item in items) Items.Add(item);
    }

    public ObservableCollection<Item> Items { get; set; } = [];
}
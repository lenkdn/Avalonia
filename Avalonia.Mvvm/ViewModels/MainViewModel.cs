using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Mvvm.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase? _currentViewModel;
    [ObservableProperty] private int _selectedIndex;

    public MainViewModel()
    {
        FirstViewModel = new FirstViewModel();
        SecondViewModel = new SecondViewModel();
        CurrentViewModel = FirstViewModel;
    }

    public MainViewModel(
        FirstViewModel firstViewModel,
        SecondViewModel secondViewModel,
        int selectedIndex)
    {
        FirstViewModel = firstViewModel;
        SecondViewModel = secondViewModel;
        SelectedIndex = selectedIndex;
        OnSelectedIndexChanged(SelectedIndex);
    }

    public FirstViewModel FirstViewModel { get; }
    public SecondViewModel SecondViewModel { get; }

    partial void OnSelectedIndexChanged(int value)
    {
        CurrentViewModel = (value + 1) switch
        {
            1 => FirstViewModel,
            2 => SecondViewModel,
            _ => null
        };
    }
}
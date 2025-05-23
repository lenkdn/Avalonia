using Avalonia.Mvvm.DTOs;
using Avalonia.Mvvm.Mappers;
using Avalonia.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.Mvvm.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private const string FileName = "SavedState.json";

    private readonly JsonService _jsonService;
    private readonly MainMapper _mainMapper;

    [ObservableProperty] private MainViewModel _mainViewModel;

    public MainWindowViewModel()
    {
        _jsonService = new JsonService();
        _mainMapper = new MainMapper();
        MainViewModel = new MainViewModel();
    }

    [RelayCommand]
    private void Save()
    {
        var dto = _mainMapper.ToDto(MainViewModel);
        _jsonService.Save(dto, FileName);
    }

    [RelayCommand]
    private void Load()
    {
        var dto = _jsonService.Load<MainDto>(FileName);
        MainViewModel = _mainMapper.ToViewModel(dto);
    }
}
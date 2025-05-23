using Avalonia.Mvvm.DTOs;
using Avalonia.Mvvm.ViewModels;

namespace Avalonia.Mvvm.Mappers;

public class MainMapper
{
    private readonly FirstMapper _firstMapper;
    private readonly SecondMapper _secondMapper;

    public MainMapper()
    {
        _firstMapper = new FirstMapper();
        _secondMapper = new SecondMapper();
    }

    public MainDto ToDto(MainViewModel viewModel)
    {
        var firstDto = _firstMapper.ToDto(viewModel.FirstViewModel);
        var secondDto = _secondMapper.ToDto(viewModel.SecondViewModel);

        var dto = new MainDto
        {
            SelectedIndex = viewModel.SelectedIndex,
            FirstDto = firstDto,
            SecondDto = secondDto
        };

        return dto;
    }

    public MainViewModel ToViewModel(MainDto? dto)
    {
        if (dto == null) return new MainViewModel();

        var firstViewModel = _firstMapper.ToViewModel(dto.FirstDto);
        var secondViewModel = _secondMapper.ToViewModel(dto.SecondDto);

        var viewModel = new MainViewModel(
            firstViewModel,
            secondViewModel,
            dto.SelectedIndex);

        return viewModel;
    }
}
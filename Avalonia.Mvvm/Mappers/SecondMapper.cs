using Avalonia.Mvvm.DTOs;
using Avalonia.Mvvm.ViewModels;

namespace Avalonia.Mvvm.Mappers;

public class SecondMapper
{
    public SecondDto ToDto(SecondViewModel viewModel)
    {
        var dto = new SecondDto
        {
            SelectedItem = viewModel.SelectedItem,
            Items = viewModel.Items
        };

        return dto;
    }

    public SecondViewModel ToViewModel(SecondDto? dto)
    {
        if (dto == null) return new SecondViewModel();

        var viewModel = new SecondViewModel(
            dto.SelectedItem,
            dto.Items);

        return viewModel;
    }
}
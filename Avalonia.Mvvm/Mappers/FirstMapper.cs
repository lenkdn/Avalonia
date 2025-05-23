using Avalonia.Mvvm.DTOs;
using Avalonia.Mvvm.ViewModels;

namespace Avalonia.Mvvm.Mappers;

public class FirstMapper
{
    public FirstDto ToDto(FirstViewModel viewModel)
    {
        var dto = new FirstDto
        {
            SelectedItem = viewModel.SelectedItem,
            Items = viewModel.Items
        };

        return dto;
    }

    public FirstViewModel ToViewModel(FirstDto? dto)
    {
        if (dto == null) return new FirstViewModel();

        var viewModel = new FirstViewModel(
            dto.SelectedItem,
            dto.Items);

        return viewModel;
    }
}
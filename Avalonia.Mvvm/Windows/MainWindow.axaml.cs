using Avalonia.Controls;
using Avalonia.Mvvm.ViewModels;

namespace Avalonia.Mvvm.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += (_, _) => (DataContext as MainWindowViewModel)?.LoadCommand.Execute(null);
        Closing += (_, _) => (DataContext as MainWindowViewModel)?.SaveCommand.Execute(null);
    }
}
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;
using Avalonia.Platform.Storage;
using avx_ui.ViewModels;

namespace avx_ui.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        AddHandler(DragDrop.DragOverEvent, DragOver);
        AddHandler(DragDrop.DropEvent, Drop);
    }

    private void DragOver(object? sender, DragEventArgs e)
    {
        var files = e.DataTransfer.TryGetFiles();
        if (files != null && files.Any())
        {
            e.DragEffects = DragDropEffects.Copy;
        }
        else
        {
            e.DragEffects = DragDropEffects.None;
        }
    }

    private void Drop(object? sender, DragEventArgs e)
    {
        if (DataContext is MainWindowViewModel vm)
        {
            var files = e.DataTransfer.TryGetFiles();
            if (files != null)
            {
                var filePaths = files.Select(f => f.TryGetLocalPath() ?? f.Name).ToList();
                vm.AddFiles(filePaths);
            }
        }
    }

    private async void SelectFiles_Click(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select Files to Convert",
            AllowMultiple = true
        });

        if (files.Count > 0 && DataContext is MainWindowViewModel vm)
        {
            var filePaths = files.Select(f => f.Path.LocalPath).ToList();
            vm.AddFiles(filePaths);
        }
    }

    private async void BrowseOutput_Click(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;

        var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Select Output Directory",
            AllowMultiple = false
        });

        if (folders.Count > 0 && DataContext is MainWindowViewModel vm)
        {
            vm.OutputDirectory = folders[0].Path.LocalPath;
        }
    }
}
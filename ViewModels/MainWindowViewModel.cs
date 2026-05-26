using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using avx_ui.Contracts;
using avx_ui.Assets.l10n;
using Avalonia;
using Avalonia.Styling;

namespace avx_ui.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IConversionService _conversionService;

    public MainWindowViewModel(IConversionService conversionService)
    {
        _conversionService = conversionService;
        
        foreach (var input in _conversionService.GetInputFormats())
        {
            InputFormats.Add(input);
        }
        
        SelectedInputFormat = InputFormats.FirstOrDefault();
        OutputDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ConvertedFiles");
    }

    public MainWindowViewModel()
    {
        // Designer only constructor
        InputFormats.Add("PNG");
        OutputFormats.Add("JPG");
        SelectedInputFormat = "PNG";
        SelectedOutputFormat = "JPG";
        OutputDirectory = "C:\\Output";
    }

    public ObservableCollection<string> InputFormats { get; } = new();
    public ObservableCollection<string> OutputFormats { get; } = new();
    public ObservableCollection<string> SelectedFiles { get; } = new();

    [ObservableProperty]
    private string? _selectedInputFormat;

    partial void OnSelectedInputFormatChanged(string? value)
    {
        OutputFormats.Clear();
        if (value != null)
        {
            foreach (var output in _conversionService.GetOutputFormats(value))
            {
                OutputFormats.Add(output);
            }
        }
        SelectedOutputFormat = OutputFormats.FirstOrDefault();
        StatusText = AppResources.Ready;
    }

    [ObservableProperty]
    private string? _selectedOutputFormat;

    [ObservableProperty]
    private string _outputDirectory = string.Empty;

    [ObservableProperty]
    private bool _overwriteExisting = false;

    [ObservableProperty]
    private bool _keepOriginal = true;

    [ObservableProperty]
    private int _progressValue = 0;

    [ObservableProperty]
    private int _progressMaximum = 100;

    [ObservableProperty]
    private string _statusText = AppResources.Ready;

    [ObservableProperty]
    private bool _isConverting = false;

    [RelayCommand]
    private void RemoveFile(string? file)
    {
        if (file != null && SelectedFiles.Contains(file))
        {
            SelectedFiles.Remove(file);
        }
    }

    [RelayCommand]
    private void ClearFiles()
    {
        SelectedFiles.Clear();
    }

    public void AddFiles(IEnumerable<string> files)
    {
        foreach (var f in files)
        {
            if (!SelectedFiles.Contains(f))
                SelectedFiles.Add(f);
        }
        StatusText = $"{SelectedFiles.Count} files selected.";
    }

    [RelayCommand]
    private void ToggleTheme()
    {
        if (Application.Current != null)
        {
            var currentTheme = Application.Current.ActualThemeVariant;
            Application.Current.RequestedThemeVariant = currentTheme == ThemeVariant.Light ? ThemeVariant.Dark : ThemeVariant.Light;
        }
    }

    [RelayCommand]
    private async Task ConvertAsync()
    {
        if (SelectedFiles.Count == 0)
        {
            StatusText = AppResources.NoFilesSelected;
            return;
        }

        if (string.IsNullOrEmpty(SelectedInputFormat) || string.IsNullOrEmpty(SelectedOutputFormat))
        {
            StatusText = AppResources.InvalidFormat;
            return;
        }

        if (!Directory.Exists(OutputDirectory))
            Directory.CreateDirectory(OutputDirectory);

        IsConverting = true;
        ProgressValue = 0;
        ProgressMaximum = SelectedFiles.Count;

        var progress = new Progress<int>(value => 
        {
            ProgressValue = value;
        });

        await _conversionService.ConvertAsync(
            SelectedFiles.ToList(), 
            SelectedInputFormat,
            SelectedOutputFormat, 
            OutputDirectory, 
            OverwriteExisting,
            progress,
            (file, error) => { /* Handle error gracefully */ },
            (statusUpdate) => StatusText = statusUpdate
        );

        IsConverting = false;
        StatusText = AppResources.ConversionComplete;
    }
}

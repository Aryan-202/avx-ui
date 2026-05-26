using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileConverterUI.Core.Interfaces;

namespace FileConverterUI.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IConversionService _conversionService;
        private HashSet<string> _selectedFiles = new HashSet<string>();

        public MainPresenter(IMainView view, IConversionService conversionService)
        {
            _view = view;
            _conversionService = conversionService;

            // Wire up view events
            _view.SelectFilesRequested += OnSelectFilesRequested;
            _view.ConvertRequested += OnConvertRequested;
            _view.BrowseOutputRequested += OnBrowseOutputRequested;
            _view.ConversionTypeChanged += OnConversionTypeChanged;
            _view.FilesDropped += HandleDroppedFiles;

            InitializeView();
        }

        private void InitializeView()
        {
            var options = _conversionService.GetSupportedConversions();
            _view.SetConversionOptions(options.Keys, options);
            _view.OutputDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ConvertedFiles");
        }

        public void HandleDroppedFiles(string[] files)
        {
            foreach (var f in files) _selectedFiles.Add(f);
            _view.SetSelectedFiles(_selectedFiles);
            _view.UpdateStatus($"{_selectedFiles.Count} files selected.");
        }

        private void OnSelectFilesRequested(object? sender, EventArgs e)
        {
            using (var openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select files to convert";
                
                string selectedType = _view.SelectedConversionType;
                if (!string.IsNullOrEmpty(selectedType) && !selectedType.StartsWith("---"))
                {
                    openFileDialog.Filter = _conversionService.GetFilterForType(selectedType);
                }
                else
                {
                    openFileDialog.Filter = "All Files|*.*";
                }

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (var f in openFileDialog.FileNames) _selectedFiles.Add(f);
                    _view.SetSelectedFiles(_selectedFiles);
                    _view.UpdateStatus($"{_selectedFiles.Count} files selected.");
                }
            }
        }

        private void OnBrowseOutputRequested(object? sender, EventArgs e)
        {
            using (var folderDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                folderDialog.Description = "Select output folder";
                folderDialog.SelectedPath = _view.OutputDirectory;

                if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _view.OutputDirectory = folderDialog.SelectedPath;
                }
            }
        }

        private async void OnConvertRequested(object? sender, EventArgs e)
        {
            if (_selectedFiles.Count == 0)
            {
                _view.ShowError("No Files", "Please select files to convert.");
                return;
            }

            string selectedType = _view.SelectedConversionType;
            if (string.IsNullOrEmpty(selectedType) || selectedType.StartsWith("---"))
            {
                _view.ShowError("Invalid Type", "Please select a valid conversion type.");
                return;
            }

            string outputDir = _view.OutputDirectory;
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            _view.EnableConversion(false);
            _view.UpdateProgress(0, _selectedFiles.Count);

            var progress = new Progress<int>(value => 
            {
                _view.UpdateProgress(value, _selectedFiles.Count);
            });

            await _conversionService.ConvertAsync(
                _selectedFiles, 
                selectedType, 
                outputDir, 
                _view.OverwriteExisting,
                progress,
                (file, error) => _view.ShowError("Error", $"Error converting {Path.GetFileName(file)}: {error}"),
                (statusText) => _view.UpdateStatus(statusText)
            );

            _view.EnableConversion(true);
            _view.UpdateStatus("Conversion completed!");
            _view.ShowSuccess("Complete", $"Successfully converted {_selectedFiles.Count} files!");
        }

        private void OnConversionTypeChanged(object? sender, EventArgs e)
        {
            _selectedFiles.Clear();
            _view.SetSelectedFiles(_selectedFiles);
            _view.UpdateStatus("Ready");
        }
    }
}

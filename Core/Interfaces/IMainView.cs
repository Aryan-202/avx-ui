using System;
using System.Collections.Generic;

namespace FileConverterUI.Core.Interfaces
{
    public interface IMainView
    {
        event EventHandler SelectFilesRequested;
        event EventHandler ConvertRequested;
        event EventHandler BrowseOutputRequested;
        event EventHandler ConversionTypeChanged;
        event Action<string[]> FilesDropped;

        string SelectedConversionType { get; set; }
        string OutputDirectory { get; set; }
        bool OverwriteExisting { get; set; }
        bool KeepOriginal { get; set; }

        void SetConversionOptions(IEnumerable<string> categories, Dictionary<string, List<string>> options);
        void SetSelectedFiles(IEnumerable<string> files);
        void UpdateProgress(int current, int total);
        void UpdateStatus(string message);
        void EnableConversion(bool enable);
        void ShowError(string title, string message);
        void ShowSuccess(string title, string message);
    }
}

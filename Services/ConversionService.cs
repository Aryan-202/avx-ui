using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using avx_ui.Contracts;

namespace avx_ui.Services;

public class ConversionService : IConversionService
{
    private readonly Dictionary<string, List<string>> _formatMap = new()
    {
        { "PNG", new List<string> { "JPG", "BMP", "GIF", "WebP", "PDF" } },
        { "JPG", new List<string> { "PNG", "BMP", "GIF", "WebP", "PDF" } },
        { "BMP", new List<string> { "PNG", "JPG", "PDF" } },
        { "DOCX", new List<string> { "PDF", "TXT" } },
        { "DOC", new List<string> { "PDF", "TXT" } },
        { "TXT", new List<string> { "PDF", "DOCX" } },
        { "XLSX", new List<string> { "CSV", "PDF" } },
        { "MP4", new List<string> { "MP3", "AVI", "MKV" } },
        { "WAV", new List<string> { "MP3", "FLAC" } },
        { "CSV", new List<string> { "XLSX", "JSON" } },
        { "JSON", new List<string> { "XML", "CSV" } }
    };

    public ConversionService()
    {
        // Make the dictionary perfectly symmetric
        var newEntries = new Dictionary<string, HashSet<string>>();
        
        foreach (var kvp in _formatMap)
        {
            var source = kvp.Key;
            foreach (var target in kvp.Value)
            {
                if (!newEntries.ContainsKey(source)) newEntries[source] = new HashSet<string>();
                if (!newEntries.ContainsKey(target)) newEntries[target] = new HashSet<string>();
                
                newEntries[source].Add(target);
                newEntries[target].Add(source); // Symmetric relation
            }
        }
        
        _formatMap.Clear();
        foreach (var kvp in newEntries)
        {
            _formatMap[kvp.Key] = kvp.Value.ToList();
        }
    }

    public IEnumerable<string> GetInputFormats() => _formatMap.Keys.OrderBy(k => k);

    public IEnumerable<string> GetOutputFormats(string inputFormat)
    {
        if (!string.IsNullOrEmpty(inputFormat) && _formatMap.TryGetValue(inputFormat, out var outputs))
            return outputs.OrderBy(o => o);
        return Enumerable.Empty<string>();
    }

    public async Task ConvertAsync(IEnumerable<string> files, string inputFormat, string outputFormat, string outputDir, bool overwrite, IProgress<int> progress, Action<string, string> onError, Action<string> onProgressUpdate)
    {
        await Task.Run(() =>
        {
            int i = 0;
            foreach (var inputFile in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(inputFile);
                string newExtension = $".{outputFormat.ToLower()}";
                string outputFile = Path.Combine(outputDir, fileName + newExtension);

                if (!overwrite && File.Exists(outputFile))
                {
                    int counter = 1;
                    while (File.Exists(outputFile))
                    {
                        outputFile = Path.Combine(outputDir, $"{fileName}_{counter}{newExtension}");
                        counter++;
                    }
                }

                onProgressUpdate?.Invoke($"Converting: {Path.GetFileName(inputFile)}");

                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "python";
                    process.StartInfo.Arguments = $"converter.py \"{inputFile}\" \"{outputFile}\" \"{inputFormat} to {outputFormat}\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.WaitForExit();
                }
                catch (Exception ex)
                {
                    onError?.Invoke(inputFile, ex.Message);
                }
                
                i++;
                progress?.Report(i);
            }
        });
    }
}

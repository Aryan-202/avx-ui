using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FileConverterUI.Core.Interfaces;

namespace FileConverterUI.Services
{
    public class ConversionService : IConversionService
    {
        public Dictionary<string, List<string>> GetSupportedConversions()
        {
            return new Dictionary<string, List<string>>
            {
                { "Image Conversions", new List<string> {
                    "PNG to JPG", "JPG to PNG", "PNG to BMP", "BMP to PNG",
                    "JPG to BMP", "BMP to JPG", "PNG to GIF", "GIF to PNG",
                    "WebP to PNG", "PNG to WebP"
                }},
                { "Document Conversions", new List<string> {
                    "DOCX to PDF", "DOC to PDF", "DOCX to TXT", "TXT to PDF",
                    "XLSX to CSV", "XLS to CSV", "PPTX to PDF"
                }},
                { "Image to PDF", new List<string> {
                    "JPG to PDF", "PNG to PDF", "BMP to PDF", "Multi-Image to PDF"
                }},
                { "Audio/Video", new List<string> {
                    "MP4 to MP3", "WAV to MP3", "FLAC to MP3", "AVI to MP4"
                }},
                { "Other Formats", new List<string> {
                    "CSV to Excel", "JSON to XML", "XML to JSON", "HTML to PDF"
                }}
            };
        }

        public string GetFilterForType(string conversionType)
        {
            var filters = new Dictionary<string, string>
            {
                { "PNG to JPG", "PNG Files|*.png" },
                { "JPG to PNG", "JPG Files|*.jpg;*.jpeg" },
                { "DOCX to PDF", "DOCX Files|*.docx" },
                { "DOC to PDF", "DOC Files|*.doc" },
                { "PNG to PDF", "Image Files|*.png;*.jpg;*.jpeg;*.bmp" },
                { "MP4 to MP3", "Video Files|*.mp4;*.avi;*.mkv" }
            };

            return filters.ContainsKey(conversionType) ? filters[conversionType] : "All Files|*.*";
        }

        private string GetOutputFileName(string inputFile, string conversionType, string outputDir, bool overwrite)
        {
            string fileName = Path.GetFileNameWithoutExtension(inputFile);
            string extension = Path.GetExtension(inputFile);

            var outputExtensions = new Dictionary<string, string>
            {
                { "PNG to JPG", ".jpg" },
                { "JPG to PNG", ".png" },
                { "DOCX to PDF", ".pdf" },
                { "PNG to PDF", ".pdf" },
                { "MP4 to MP3", ".mp3" }
            };

            string newExtension = outputExtensions.ContainsKey(conversionType) ? outputExtensions[conversionType] : extension;
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

            return outputFile;
        }

        public async Task ConvertAsync(IEnumerable<string> files, string conversionType, string outputDir, bool overwrite, IProgress<int> progress, Action<string, string> onError, Action<string> onProgressUpdate)
        {
            await Task.Run(() =>
            {
                int i = 0;
                foreach (var inputFile in files)
                {
                    string outputFile = GetOutputFileName(inputFile, conversionType, outputDir, overwrite);
                    onProgressUpdate?.Invoke($"Converting: {Path.GetFileName(inputFile)}");

                    try
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = "python";
                        process.StartInfo.Arguments = $"converter.py \"{inputFile}\" \"{outputFile}\" \"{conversionType}\"";
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
}

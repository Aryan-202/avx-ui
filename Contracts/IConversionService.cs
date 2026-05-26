using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace avx_ui.Contracts;

public interface IConversionService
{
    IEnumerable<string> GetInputFormats();
    IEnumerable<string> GetOutputFormats(string inputFormat);
    Task ConvertAsync(IEnumerable<string> files, string inputFormat, string outputFormat, string outputDir, bool overwrite, IProgress<int> progress, Action<string, string> onError, Action<string> onProgressUpdate);
}

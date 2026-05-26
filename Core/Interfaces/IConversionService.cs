using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileConverterUI.Core.Interfaces
{
    public interface IConversionService
    {
        Dictionary<string, List<string>> GetSupportedConversions();
        string GetFilterForType(string conversionType);
        Task ConvertAsync(IEnumerable<string> files, string conversionType, string outputDir, bool overwrite, IProgress<int> progress, Action<string, string> onError, Action<string> onProgressUpdate);
    }
}

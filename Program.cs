using System;
using System.Windows.Forms;
using FileConverterUI.App;

namespace FileConverterUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            AppBootstrapper.Run();
        }
    }
}
using System;
using System.Windows.Forms;
using FileConverterUI.Core.Interfaces;
using FileConverterUI.Presenters;
using FileConverterUI.Services;
using FileConverterUI.UI.Views;

namespace FileConverterUI.App
{
    public static class AppBootstrapper
    {
        public static void Run()
        {
            // Simple Dependency Injection setup
            IConversionService conversionService = new ConversionService();
            MainForm mainView = new MainForm();
            
            // Initialize Presenter
            MainPresenter presenter = new MainPresenter(mainView, conversionService);

            // Run Application
            Application.Run(mainView);
        }
    }
}

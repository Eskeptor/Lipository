// ======================================================================================================
// File Name        : App.xaml.cs
// Project          : Lipository.App
// Last Update      : 2026.09.19 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;

using Esk.GearForge.SQLiteUtil;
using Esk.GearForge.SQLiteUtil.Query;

namespace Lipository.App
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        internal static MainWindow MainWindow { get => _mainWindow; }
        private static MainWindow _mainWindow = null!;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            CheckDatabase();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            _mainWindow = new MainWindow();
            _mainWindow.Activate();
        }

        private void CheckDatabase()
        {
            if (!Directory.Exists(Globals.Constants.Database.DirPath))
            {
                Directory.CreateDirectory(Globals.Constants.Database.DirPath);
            }

            using (Manager dbManager = new Manager())
            {
                ErrorCode errorCode = dbManager.Connect(Globals.Constants.Database.FullPath, true); 
                if (errorCode != ErrorCode.Success)
                {
                    ContentDialog errorDialog = new ContentDialog()
                    {
                        Title = "Database Connection Error",
                        Content = $"Failed to connect to the database. Error code: {errorCode}",
                        CloseButtonText = "OK",
                        XamlRoot = App.MainWindow.Content.XamlRoot
                    };
                    _ = errorDialog.ShowAsync();
                    return;
                }
                errorCode = dbManager.ExistTable(Globals.Constants.Database.MainTableName, out bool tableExists);
                if (errorCode != ErrorCode.Success)
                {
                    ContentDialog errorDialog = new ContentDialog()
                    {
                        Title = "Database Error",
                        Content = $"Failed to check if the main table exists. Error code: {errorCode}",
                        CloseButtonText = "OK",
                        XamlRoot = App.MainWindow.Content.XamlRoot
                    };
                    _ = errorDialog.ShowAsync();
                    return;
                }
                if (!tableExists)
                {
                    CreateTableQuery query = Globals.DatabaseUtil.MakeCreateTableQuery();
                    errorCode = dbManager.CreateTable(query);
                    if (errorCode != ErrorCode.Success)
                    {
                        string msg = $"Failed to create the main table. Error code: {errorCode}";
                        ContentDialog dialog = new ContentDialog()
                        {
                            Title = "Database Table Creation Error",
                            Content = msg,
                            CloseButtonText = "OK",
                            XamlRoot = App.MainWindow.Content.XamlRoot
                        };
                        _ = dialog.ShowAsync();
                        return;
                    }
                }
            }
        }
    }
}

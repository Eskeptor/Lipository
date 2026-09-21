// ======================================================================================================
// File Name        : DatabasePage.xaml.cs
// Project          : Lipository.App
// Last Update      : 2026.09.21 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using CommunityToolkit.WinUI.UI.Controls;

using Lipository.App.ViewModel;
using Lipository.App.Datas;

namespace Lipository.App.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DatabasePage : Page
    {
        public DatabasePageViewModel ViewModel { get; } = new DatabasePageViewModel();

        private static readonly HashSet<string> HiddenColumns = new HashSet<string>()
        {
            nameof(DatabaseItem.ReleaseDateString),
            nameof(DatabaseItem.LastDateString)
        };

        public DatabasePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ReloadCommand.Execute(null);
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (HiddenColumns.Contains(e.PropertyName))
            {
                e.Cancel = true;
            }
        }
    }
}

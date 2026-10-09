// ======================================================================================================
// File Name        : MainPage.xaml.cs
// Project          : Lipository.App
// Last Update      : 2026.10.09 - yc.jeon (Eskeptor)
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

using Lipository.App.Datas;
using Lipository.App.ViewModel;

namespace Lipository.App.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public SettingsDataModel SettingsDataModel { get => SettingsDataModel.Model; }

        public MainPageViewModel ViewModel { get; } = new MainPageViewModel();

        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.BuildTree();
            tvMain.SelectedItem = ViewModel.SelectedNode;
        }

        private void TvMain_ItemInvoked(object sender, TreeViewItemInvokedEventArgs e)
        {
            if (e.InvokedItem is not MainTreeNodeItem node)
            {
                return;
            }

            ViewModel.SelectedNode = node;
        }
    }
}

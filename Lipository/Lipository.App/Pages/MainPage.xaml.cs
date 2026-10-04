// ======================================================================================================
// File Name        : MainPage.xaml.cs
// Project          : Lipository.App
// Last Update      : 2026.09.16 - yc.jeon (Eskeptor)
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

        private void Canvas_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (e.OriginalSource is not FrameworkElement element)
            {
                return;
            }
            if (element.DataContext is not DatabaseItem item)
            {
                return;
            }
            ViewModel.SelectedItem = item;
            if (ViewModel.RunItemCommand.CanExecute(null))
            {
                ViewModel.RunItemCommand.Execute(null);
            }
        }
    }
}

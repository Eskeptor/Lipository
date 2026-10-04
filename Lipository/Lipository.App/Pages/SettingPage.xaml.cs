// ======================================================================================================
// File Name        : SettingPage.xaml.cs
// Project          : Lipository.App
// Last Update      : 2026.10.04 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using Lipository.App.ViewModel;

namespace Lipository.App.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPageViewModel ViewModel { get; } = new SettingPageViewModel();

        private bool _allowNavigation;

        public SettingPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (_allowNavigation ||
                !ViewModel.SettingsData.IsChanged)
            {
                base.OnNavigatingFrom(e);
                return;
            }

            e.Cancel = true;
            NavigationMode mode = e.NavigationMode;
            Type sourcePageType = e.SourcePageType;
            object? parameter = e.Parameter;
            _ = HandleUnsavedChangesAsync(mode, sourcePageType, parameter);

            base.OnNavigatingFrom(e);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ReloadCommand.Execute(null);
        }

        private async Task HandleUnsavedChangesAsync(NavigationMode mode, Type sourcePageType, object? parameter)
        {
            ContentDialog dlg = new ContentDialog()
            {
                Title = "Unsaved Changes",
                Content = "You have unsaved changes. Do you want to save them before leaving?",
                PrimaryButtonText = "Save",
                SecondaryButtonText = "Discard",
                CloseButtonText = "Cancel",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };
            ContentDialogResult result = await dlg.ShowAsync();
            switch (result)
            {
                case ContentDialogResult.Primary:       // Save
                    ViewModel.SaveCommand.Execute(null);
                    RunNavigate(mode, sourcePageType, parameter);
                    break;
                case ContentDialogResult.Secondary:     // Discard
                    RunNavigate(mode, sourcePageType, parameter);
                    break;
                default:
                    break;
            }
        }

        private void RunNavigate(NavigationMode mode, Type sourcePageType, object? parameter)
        {
            if (Frame == null)
            {
                return;
            }

            _allowNavigation = true;
            try
            {
                if (mode == NavigationMode.Back)
                {
                    if (Frame.CanGoBack)
                    {
                        Frame.GoBack();
                    }
                }
                else
                {
                    Frame.Navigate(sourcePageType, parameter);
                }
            }
            finally
            {
                _allowNavigation = false;
            }
        }
    }
}

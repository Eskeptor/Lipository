// ======================================================================================================
// File Name        : MainWindow.cs
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

using Lipository.App.Globals;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Lipository.App
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NvMain_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                sender.Header = "Settings";
                mainFrame.Navigate(typeof(Pages.SettingPage));
            }
            else if (args.SelectedItem is NavigationViewItem selectedItem &&
                selectedItem.Tag is string tag)
            {
                string pageName = $"{Constants.Pages.RootPath}.{tag}";
                if (NavigationMapper.PageMap.TryGetValue(pageName, out (Type, string) mapData))
                {
                    sender.Header = mapData.Item2;
                    mainFrame.Navigate(mapData.Item1);
                }
            }
        }
    }
}

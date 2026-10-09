// ======================================================================================================
// File Name        : MainPageViewModel.cs
// Project          : Lipository.App
// Last Update      : 2026.10.09 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.UI.Xaml.Controls;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using Esk.GearForge.CSUtil;

using Lipository.App.Datas;
using Lipository.App.Globals;


namespace Lipository.App.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<DatabaseItem> Items { get => DatabaseItemModel.Model.Items; }

        public ObservableCollection<MainTreeNodeItem> TreeNodes { get; } = new ObservableCollection<MainTreeNodeItem>();

        public DatabaseItem? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
        private DatabaseItem? _selectedItem;

        public MainTreeNodeItem? SelectedNode
        {
            get => _selectedNode;
            set => SetProperty(ref _selectedNode, value);
        }
        private MainTreeNodeItem? _selectedNode;

        public MainPageViewModel()
        {
            WeakReferenceMessenger.Default.Register<RunItemMessage>(this, OnRunItemMessageReceived);
        }

        public void BuildTree()
        {
            TreeNodes.Clear();

            MainTreeNodeItem rootAll = new MainTreeNodeItem()
            {
                Name = "All",
                IsExpanded = false,
            };
            MainTreeNodeItem rootEtc = new MainTreeNodeItem()
            {
                Name = "ETC",
                IsExpanded = false,
            };
            MainTreeNodeItem rootEtc1 = new MainTreeNodeItem()
            {
                Name = SettingsDataModel.Model.Etc1Info.Text,
                IsExpanded = false,
            };
            rootEtc.Children.Add(rootEtc1);
            MainTreeNodeItem rootEtc2 = new MainTreeNodeItem()
            {
                Name = SettingsDataModel.Model.Etc2Info.Text,
                IsExpanded = false,
            };
            rootEtc.Children.Add(rootEtc2);
            MainTreeNodeItem rootEtc3 = new MainTreeNodeItem()
            {
                Name = SettingsDataModel.Model.Etc3Info.Text,
                IsExpanded = false,
            };
            rootEtc.Children.Add(rootEtc3);
            MainTreeNodeItem rootEtc4 = new MainTreeNodeItem()
            {
                Name = SettingsDataModel.Model.Etc4Info.Text,
                IsExpanded = false,
            };
            rootEtc.Children.Add(rootEtc4);
            TreeNodes.Add(rootAll);
            TreeNodes.Add(rootEtc);

            _selectedNode = rootAll;
        }

        private void OnRunItemMessageReceived(object sender, RunItemMessage message)
        {
            if (sender is not MainPageViewModel viewModel)
            {
                return;
            }
            viewModel.SelectedItem = message.Value;
            if (viewModel.RunItemCommand.CanExecute(null))
            {
                viewModel.RunItemCommand.Execute(null);
            }
        }

        

        [RelayCommand(CanExecute = nameof(CanRunItem))]
        private void RunItem()
        {
            DatabaseItem item = SelectedItem!;

            bool isRun = false;
            if (File.Exists(item.DataPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(item.DataPath)
                {
                    UseShellExecute = true
                };
                try
                {
                    _ = Process.Start(startInfo);
                    isRun = true;
                }
                catch (Exception ex)
                {
                    ContentDialog dlg = new ContentDialog()
                    {
                        Title = "Error",
                        Content = $"Failed to run the item: {ex.Message}",
                        CloseButtonText = "OK",
                        XamlRoot = App.MainWindow.Content.XamlRoot
                    };
                    _ = dlg.ShowAsync();
                    return;
                }
            }
            else if (item.DataPath.StartsWithOrdinal("http://") 
                || item.DataPath.StartsWithOrdinal("https://"))
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo("chrome.exe")
                    {
                        UseShellExecute = true,
                        Arguments = $"{item.DataPath} --incognito"
                    };
                    _ = Process.Start(startInfo);
                    isRun = true;
                }
                catch
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(item.DataPath)
                    {
                        UseShellExecute = true
                    };
                    if (Process.Start(startInfo) != null)
                    {
                        isRun = true;
                    }
                }
            }

            if (isRun)
            {

            }
            else
            {
                ContentDialog dlg = new ContentDialog()
                {
                    Title = "Error",
                    Content = $"Failed to run the item: {item.DataPath}",
                    CloseButtonText = "OK",
                    XamlRoot = App.MainWindow.Content.XamlRoot
                };
                _ = dlg.ShowAsync();
            }
        }

        private bool CanRunItem()
        {
            return SelectedItem != null;
        }
    }
}

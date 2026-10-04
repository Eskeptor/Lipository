// ======================================================================================================
// File Name        : MainPageViewModel.cs
// Project          : Lipository.App
// Last Update      : 2026.10.03 - yc.jeon (Eskeptor)
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

using Lipository.App.Datas;

using Esk.GearForge.CSUtil;

namespace Lipository.App.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<DatabaseItem> Items { get => DatabaseItemModel.Model.Items; }

        public DatabaseItem? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
        private DatabaseItem? _selectedItem;

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
                    if (Process.Start(startInfo) != null)
                    {
                        isRun = true;
                    }
                }
                catch (Exception ex)
                {
                    ContentDialog dlg = new ContentDialog()
                    {
                        Title = "Error",
                        Content = $"Failed to run the item: {ex.Message}",
                        CloseButtonText = "OK"
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
                    if (Process.Start(startInfo) != null)
                    {
                        isRun = true;
                    }
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
                    CloseButtonText = "OK"
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

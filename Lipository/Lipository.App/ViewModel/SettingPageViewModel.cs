// ======================================================================================================
// File Name        : SettingPageViewModel.cs
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

using Esk.GearForge.CSUtil;

using Lipository.App.Datas;

namespace Lipository.App.ViewModel
{
    public partial class SettingPageViewModel : ObservableObject
    {
        public SettingsDataModel SettingsData { get => SettingsDataModel.Model; }

        public DatabaseItem PreviewItem { get; } = new DatabaseItem()
        {
            Title = "Preview Title",
            SubTitle = "Preview Subtitle",
            ImagePath = $"{FileUtil.GetCurrentPath(FileUtil.EnvironmentTypes.WPF)}/Assets/Square150x150Logo.scale-200.png",
            Rate = 10,
            Etc1 = "Preview Etc1",
            Etc2 = "Preview Etc2",
            Etc3 = "Preview Etc3",
            Etc4 = "Preview Etc4",
            Memo = "Preview Memo"
        };

        [RelayCommand]
        private void Save()
        {
            SettingsDataModel.Model.SaveData();
            ContentDialog dlg = new ContentDialog()
            {
                Title = "Settings Saved",
                Content = "The settings has been saved successfully.",
                CloseButtonText = "OK",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };
            _ = dlg.ShowAsync();
            OnPropertyChanged(nameof(SettingsData));
        }

        [RelayCommand]
        private void Reload()
        {
            SettingsDataModel.Model.LoadData();
            OnPropertyChanged(nameof(SettingsData));
        }
    }
}

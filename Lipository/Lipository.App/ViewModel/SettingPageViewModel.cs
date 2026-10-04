// ======================================================================================================
// File Name        : SettingPageViewModel.cs
// Project          : Lipository.App
// Last Update      : 2026.10.04 - yc.jeon (Eskeptor)
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

namespace Lipository.App.ViewModel
{
    public partial class SettingPageViewModel : ObservableObject
    {
        public SettingsDataModel SettingsData { get => SettingsDataModel.Model; }

        [RelayCommand]
        private void Save()
        {
            SettingsDataModel.Model.SaveData();
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

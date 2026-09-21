// ======================================================================================================
// File Name        : DatabasePageViewModel.cs
// Project          : Lipository.App
// Last Update      : 2026.09.21 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.UI.Xaml.Controls;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Lipository.App.Datas;

namespace Lipository.App.ViewModel
{
    public partial class DatabasePageViewModel : ObservableObject
    {
        public ObservableCollection<DatabaseItem> Items { get => DatabaseItemModel.Model.Items; }

        public DatabaseItem? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
        private DatabaseItem? _selectedItem;

        [RelayCommand]
        private void Reload()
        {
            DatabaseItemModel.Model.ReloadDatabase();
            OnPropertyChanged(nameof(Items));
        }

        [RelayCommand]
        private void Save()
        {
            bool result = DatabaseItemModel.Model.SaveDatabase();
            if (result)
            {
                ContentDialog dlg = new ContentDialog()
                {
                    Title = "Database Saved",
                    Content = "The database has been saved successfully.",
                    CloseButtonText = "OK",
                    XamlRoot = App.MainWindow.Content.XamlRoot
                };
                _ = dlg.ShowAsync();
            }
        }

        [RelayCommand]
        private void Add()
        {
            DatabaseItem item = new DatabaseItem()
            {
                Title = "NewItem",
                ReleaseDate = DateTime.Now,
            };
            DatabaseItemModel.Model.AddItem(item, true);
            OnPropertyChanged(nameof(Items));
        }

        [RelayCommand(CanExecute = nameof(CanDelete))]
        private void Delete()
        {
            DatabaseItemModel.Model.DeleteItem(_selectedItem);
            OnPropertyChanged(nameof(Items));
        }

        private bool CanDelete()
        {
            if (_selectedItem == null)
            {
                return false;
            }
            return true;
        }

        [RelayCommand]
        private async Task ImportAsync()
        {
            // TODO [2026.09.16] Implement logic to import data from a file
            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task ExportAsync()
        {
            // TODO [2026.09.16] Implement logic to export data to a file
            await Task.CompletedTask;
        }
    }
}

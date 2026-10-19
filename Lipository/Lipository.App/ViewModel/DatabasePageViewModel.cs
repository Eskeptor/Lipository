// ======================================================================================================
// File Name        : DatabasePageViewModel.cs
// Project          : Lipository.App
// Last Update      : 2026.10.19 - yc.jeon (Eskeptor)
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

using Windows.Storage.Pickers;
using Windows.Storage;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Esk.GearForge.CSUtil;

using Lipository.App.Datas;
using Lipository.App.Globals;

namespace Lipository.App.ViewModel
{
    public partial class DatabasePageViewModel : ObservableObject
    {
        public ObservableCollection<DatabaseItem> Items { get => DatabaseItemModel.Model.Items; }

        public DatabaseItem? SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (SetProperty(ref _selectedItem, value))
                {
                    DeleteCommand.NotifyCanExecuteChanged();
                }
            }
        }
        private DatabaseItem? _selectedItem;

        public bool IsInitLoaded { get => DatabaseItemModel.Model.IsInitLoaded; }

        [RelayCommand]
        private void Reload()
        {
            DatabaseItemModel.Model.ReloadDatabase();
            OnPropertyChanged(nameof(Items));
        }

        [RelayCommand]
        private async Task Save()
        {
            ContentDialog dlg = new ContentDialog()
            {
                Title = "Save Database",
                Content = "Are you sure you want to save the database?",
                PrimaryButtonText = "Yes",
                CloseButtonText = "No",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };
            ContentDialogResult result = await dlg.ShowAsync();
            if (result != ContentDialogResult.Primary)
            {
                return;
            }

            bool isSave = DatabaseItemModel.Model.SaveDatabase();
            if (isSave)
            {
                dlg = new ContentDialog()
                {
                    Title = "Database Saved",
                    Content = "The database has been saved successfully.",
                    CloseButtonText = "OK",
                    XamlRoot = App.MainWindow.Content.XamlRoot
                };
                _ = dlg.ShowAsync();
                OnPropertyChanged(nameof(Items));
            }
        }

        [RelayCommand]
        private void Add()
        {
            DatabaseItem item = new DatabaseItem()
            {
                Title = "NewItem",
                ReleaseDate = DateTime.Now,
                LastDate = DateTime.Now,
            };
            DatabaseItemModel.Model.AddItem(item, true);
            //OnPropertyChanged(nameof(Items));
        }

        [RelayCommand(CanExecute = nameof(CanDelete))]
        private void Delete()
        {
            DatabaseItemModel.Model.DeleteItem(_selectedItem);
            //OnPropertyChanged(nameof(Items));
        }

        private bool CanDelete()
        {
            return SelectedItem != null;
        }

        [RelayCommand]
        private async Task ImportCsvAsync()
        {
            // TODO [2026.09.16] Implement logic to import data from a file
            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task ExportCsvAsync()
        {
            // TODO [2026.09.16] Implement logic to export data to a file
            await Task.CompletedTask;
        }

        [RelayCommand(CanExecute = nameof(CanMatchDatabase))]
        private async Task MatchDatabase()
        {
            ContentDialog dlg = new ContentDialog()
            {
                Title = "Match Database",
                Content = "Are you sure you want to match the database?",
                PrimaryButtonText = "Yes",
                CloseButtonText = "No",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };
            ContentDialogResult result = await dlg.ShowAsync();
            if (result != ContentDialogResult.Primary)
            {
                return;
            }

            SelectedItem = null;
            int notMatchedCount = DatabaseItemModel.Model.MatchDatabase();
            if (notMatchedCount > 0)
            {
                OnPropertyChanged(nameof(Items));

                dlg = new ContentDialog()
                {
                    Title = "Database Matched",
                    Content = $@"The database has been matched successfully.
{notMatchedCount} items were not matched.",
                    CloseButtonText = "OK",
                    XamlRoot = App.MainWindow.Content.XamlRoot
                };
                _ = dlg.ShowAsync();
            }
        }

        private bool CanMatchDatabase()
        {
            if (DatabaseItemModel.Model.Items.Count == 0)
            {
                return false;
            }
            return true;
        }

        [RelayCommand(CanExecute = nameof(CanReindexingFileID))]
        private async Task ReindexingFileIDAsync()
        {
            ContentDialog dlg = new ContentDialog()
            {
                Title = "Reindexing File ID",
                Content = "Are you sure you want to reindex the file IDs?",
                PrimaryButtonText = "Yes",
                CloseButtonText = "No",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };
            ContentDialogResult result = await dlg.ShowAsync();
            if (result != ContentDialogResult.Primary)
            {
                return;
            }

            SelectedItem = null;
            bool isIndexed = DatabaseItemModel.Model.ReindexingFileID();
            if (isIndexed)
            {
                dlg = new ContentDialog()
                {
                    Title = "File IDs Reindexed",
                    Content = "The file IDs have been reindexed successfully.",
                    CloseButtonText = "OK",
                    XamlRoot = App.MainWindow.Content.XamlRoot
                };
                _ = dlg.ShowAsync();
                OnPropertyChanged(nameof(Items));
            }
        }

        private bool CanReindexingFileID()
        {
            if (DatabaseItemModel.Model.Items.Count == 0)
            {
                return false;
            }
            return true;
        }

        [RelayCommand]
        private async Task ImportFolderAsync()
        {
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.FileTypeFilter.Add("*");
            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);
            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder == null)
            {
                return;
            }

            bool result = await AddItemFromFolder(folder.Path);
        }

        private async Task<bool> AddItemFromFolder(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                return false;
            }

            ObservableCollection<DatabaseItem> dbItems = DatabaseItemModel.Model.Items;
            HashSet<string> dbItemsSet = new HashSet<string>(dbItems.Count);
            foreach (DatabaseItem dbItem in dbItems)
            {
                dbItemsSet.Add(dbItem.DataPath);
            }

            string rawMediaExtensions = string.IsNullOrWhiteSpace(SettingsDataModel.Model.MediaExtensions) ?
                Constants.Settings.MediaExtensions :
                SettingsDataModel.Model.MediaExtensions;
            string rawImageExtensions = string.IsNullOrWhiteSpace(SettingsDataModel.Model.ImageExtensions) ?
                Constants.Settings.ImageExtensions :
                SettingsDataModel.Model.ImageExtensions;
            string[] mediaExtensions = rawMediaExtensions.Split(',');
            string[] imageExtensions = rawImageExtensions.Split(',');
            FileInfo[] allFiles = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in allFiles)
            {
                foreach (string mediaExtension in mediaExtensions)
                {
                    if (!file.Extension.EndsWithOrdinal(mediaExtension) ||
                        dbItemsSet.Contains(file.FullName))
                    {
                        continue;
                    }

                    DatabaseItem item = new DatabaseItem()
                    {
                        Title = Path.GetFileNameWithoutExtension(file.Name),
                        DataPath = file.FullName,
                        ReleaseDate = DateTime.Now,
                        LastDate = DateTime.Now,
                    };
                    foreach (string imageExtension in imageExtensions)
                    {
                        string imagePath = $"{file.FullName.Substring(0, file.FullName.LastIndexOf('.') + 1)}{imageExtension}";
                        if (File.Exists(imagePath))
                        {
                            item.ImagePath = imagePath;
                            break;
                        }
                    }
                    DatabaseItemModel.Model.AddItem(item, true);
                    break;
                }
            }

            return true;
        }

    }
}

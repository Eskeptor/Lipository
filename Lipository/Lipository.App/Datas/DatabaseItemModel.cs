// ======================================================================================================
// File Name        : DatabaseItemModel.cs
// Project          : Lipository.App
// Last Update      : 2026.09.19 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.UI.Xaml.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using Esk.GearForge.SQLiteUtil;
using Esk.GearForge.SQLiteUtil.Query;
using Esk.GearForge.CSUtil;

namespace Lipository.App.Datas
{
    public partial class DatabaseItemModel : ObservableObject
    {
        public static DatabaseItemModel Model { get => _instance.Value; }
        private static readonly Lazy<DatabaseItemModel> _instance = new Lazy<DatabaseItemModel>(() => new DatabaseItemModel());

        public ObservableCollection<DatabaseItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        private ObservableCollection<DatabaseItem> _items = new ObservableCollection<DatabaseItem>();

        private int _lastID;

        private DatabaseItemModel()
        {

        }

        public bool AddItem(DatabaseItem item, bool useAutoInc = false)
        {
            if (useAutoInc)
            {
                item.ID = GetNextID();
            }
            else
            {
                IEnumerable<DatabaseItem> findItem = _items.Where(x => x.ID == item.ID);
                if (findItem.Any())
                {
                    return false;
                }
            }
            Items.Add(item);
            return true;
        }

        public bool DeleteItem(DatabaseItem? item)
        {
            if (item == null)
            {
                return false;
            }
            return Items.Remove(item);
        }

        public bool SaveDatabase()
        {
            using (Manager dbManager = new Manager())
            {
                ErrorCode errorCode = dbManager.Connect(Globals.Constants.Database.FullPath, true);
                if (errorCode != ErrorCode.Success)
                {
                    string msg = $"Failed to connect to the database. Error code: {errorCode}";
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Database Connection Error",
                        Content = msg,
                        CloseButtonText = "OK",
                        XamlRoot = App.MainWindow.Content.XamlRoot
                    };
                    _ = dialog.ShowAsync();
                    return false;
                }
                
                DeleteQuery deleteQuery = new DeleteQuery(Globals.Constants.Database.MainTableName);
                errorCode = dbManager.Delete(deleteQuery);
                if (errorCode != ErrorCode.Success)
                {
                    string msg = $"Failed to delete data from the main table. Error code: {errorCode}";
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Database Delete Error",
                        Content = msg,
                        CloseButtonText = "OK",
                        XamlRoot = App.MainWindow.Content.XamlRoot
                    };
                    _ = dialog.ShowAsync();
                    return false;
                }

                dbManager.BeginTransaction();
                try
                {
                    foreach (DatabaseItem item in _items)
                    {
                        InsertQuery insertQuery = new InsertQuery(Globals.Constants.Database.MainTableName);
                        insertQuery.Insert(new InsertQueryData[]
                        {
                            new InsertQueryData()
                            {
                                Value = item.ID.ToStringInvariantCulture(),
                                Type = QueryDataType.Integer
                            },
                            new InsertQueryData()
                            {
                                Value = item.ImagePath,
                                Type = QueryDataType.Text
                            },
                            new InsertQueryData()
                            {
                                Value = item.Title,
                                Type = QueryDataType.Text
                            },
                            new InsertQueryData()
                            {
                                Value = item.SubTitle,
                                Type = QueryDataType.Text
                            },
                            new InsertQueryData()
                            {
                                Value = item.DataPath,
                                Type = QueryDataType.Text
                            },
                            new InsertQueryData()
                            {
                                Value = item.Rate.ToStringInvariantCulture(),
                                Type = QueryDataType.Integer
                            },
                            new InsertQueryData()
                            {
                                Value = item.Etc1,
                                Type = QueryDataType.Text
                            },
                            new InsertQueryData()
                            {
                                Value = item.Etc2,
                                Type = QueryDataType.Text
                            },
                            new InsertQueryData()
                            {
                                Value = item.Etc3,
                                Type = QueryDataType.Text
                            },
                            new InsertQueryData()
                            {
                                Value = item.Etc4,
                                Type = QueryDataType.Text
                            },
                            new InsertQueryData()
                            {
                                Value = item.Memo,
                                Type = QueryDataType.Text
                            },
                            new InsertQueryData()
                            {
                                Value = item.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                Type = QueryDataType.Text
                            },
                            new InsertQueryData()
                            {
                                Value = item.LastDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                Type = QueryDataType.Text
                            },
                        });
                        errorCode = dbManager.Insert(insertQuery);
                        if (errorCode != ErrorCode.Success)
                        {
                            string msg = $"Failed to insert data into the main table. Error code: {errorCode}";
                            ContentDialog dialog = new ContentDialog()
                            {
                                Title = "Database Insert Error",
                                Content = msg,
                                CloseButtonText = "OK",
                                XamlRoot = App.MainWindow.Content.XamlRoot
                            };
                            _ = dialog.ShowAsync();
                            dbManager.RollbackTransaction(true);
                            return false;
                        }
                    }
                }
                finally
                {
                    dbManager.EndTransaction();
                }
            }
            return true;
        }

        public bool ReloadDatabase()
        {
            using (Manager dbManager = new Manager())
            {
                ErrorCode errorCode = dbManager.Connect(Globals.Constants.Database.FullPath, true);
                if (errorCode != ErrorCode.Success)
                {
                    string msg = $"Failed to connect to the database. Error code: {errorCode}";
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Database Connection Error",
                        Content = msg,
                        CloseButtonText = "OK",
                        XamlRoot = App.MainWindow.Content.XamlRoot
                    };
                    _ = dialog.ShowAsync();
                    return false;
                }

                errorCode = dbManager.ExistTable(Globals.Constants.Database.MainTableName, out bool exist);
                if (errorCode != ErrorCode.Success)
                {
                    string msg = $"Failed to check if the main table exists. Error code: {errorCode}";
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Database Table Check Error",
                        Content = msg,
                        CloseButtonText = "OK",
                        XamlRoot = App.MainWindow.Content.XamlRoot
                    };
                    _ = dialog.ShowAsync();
                    return false;
                }
                if (!exist)
                {
                    CreateTableQuery query = Globals.DatabaseUtil.MakeCreateTableQuery();
                    errorCode = dbManager.CreateTable(query);
                    if (errorCode != ErrorCode.Success)
                    {
                        string msg = $"Failed to create the main table. Error code: {errorCode}";
                        ContentDialog dialog = new ContentDialog()
                        {
                            Title = "Database Table Creation Error",
                            Content = msg,
                            CloseButtonText = "OK",
                            XamlRoot = App.MainWindow.Content.XamlRoot
                        };
                        _ = dialog.ShowAsync();
                        return false;
                    }
                    Items = new ObservableCollection<DatabaseItem>();
                }
                else
                {
                    SelectQuery query = new SelectQuery(Globals.Constants.Database.MainTableName);
                    errorCode = dbManager.Select(query, out DataSet readData);
                    if (errorCode != ErrorCode.Success)
                    {
                        string msg = $"Failed to read data from the main table. Error code: {errorCode}";
                        ContentDialog dialog = new ContentDialog()
                        {
                            Title = "Database Read Error",
                            Content = msg,
                            CloseButtonText = "OK",
                            XamlRoot = App.MainWindow.Content.XamlRoot
                        };
                        _ = dialog.ShowAsync();
                        return false;
                    }
                    DataTable table = readData.Tables[0];
                    if (table == null)
                    {
                        string msg = "Failed to read data from the main table. The data table is null.";
                        ContentDialog dialog = new ContentDialog()
                        {
                            Title = "Database Read Error",
                            Content = msg,
                            CloseButtonText = "OK",
                            XamlRoot = App.MainWindow.Content.XamlRoot
                        };
                        _ = dialog.ShowAsync();
                        return false;
                    }
                    if (table.Rows.Count == 0)
                    {
                        Items = new ObservableCollection<DatabaseItem>();
                    }
                    else
                    {
                        List<DatabaseItem> items = new List<DatabaseItem>(table.Rows.Count);
                        foreach (DataRow row in table.Rows)
                        {
                            DatabaseItem item = new DatabaseItem()
                            {
                                ID = Convert.ToInt32(row["ID"]),
                                ImagePath = row["ImagePath"]?.ToString() ?? string.Empty,
                                Title = row["Title"]?.ToString() ?? string.Empty,
                                SubTitle = row["SubTitle"]?.ToString() ?? string.Empty,
                                DataPath = row["DataPath"]?.ToString() ?? string.Empty,
                                Rate = Convert.ToInt32(row["Rate"]),
                                Etc1 = row["Etc1"]?.ToString() ?? string.Empty,
                                Etc2 = row["Etc2"]?.ToString() ?? string.Empty,
                                Etc3 = row["Etc3"]?.ToString() ?? string.Empty,
                                Etc4 = row["Etc4"]?.ToString() ?? string.Empty,
                                Memo = row["Memo"]?.ToString() ?? string.Empty,
                            };
                            string releaseDateStr = row["ReleaseDate"]?.ToString() ?? string.Empty;
                            if (DateTime.TryParse(releaseDateStr, out DateTime releaseDate))
                            {
                                item.ReleaseDate = releaseDate;
                            }
                            string lastDateStr = row["LastDate"]?.ToString() ?? string.Empty;
                            if (DateTime.TryParse(lastDateStr, out DateTime lastDate))
                            {
                                item.LastDate = lastDate;
                            }
                            items.Add(item);
                        }

                        Items = new ObservableCollection<DatabaseItem>(items);
                    }
                }
            }
            return true;
        }

        private int GetNextID()
        {
            int newID = _lastID + 1;
            while (true)
            {
                IEnumerable<DatabaseItem> findItem = _items.Where(x => x.ID == newID);
                if (!findItem.Any())
                {
                    break;
                }
                ++newID;
            }
            _lastID = newID;
            return newID;
        }
    }
}

// ======================================================================================================
// File Name        : DatabaseItem.cs
// Project          : Lipository.App
// Last Update      : 2026.09.21 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using Esk.GearForge.CSUtil;
using Lipository.App.Globals;

namespace Lipository.App.Datas
{
    public partial class DatabaseItem : ObservableObject
    {
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private int _id;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        private string _title = string.Empty;

        public string SubTitle
        {
            get => _subTitle;
            set => SetProperty(ref _subTitle, value);
        }
        private string _subTitle = string.Empty;

        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }
        private string _imagePath = string.Empty;

        public string DataPath
        {
            get => _dataPath;
            set => SetProperty(ref _dataPath, value);
        }
        private string _dataPath = string.Empty;

        public int Rate
        {
            get => _rate;
            set
            {
                if (value < 0 ||
                    value > 10)
                {
                    return;
                }
                SetProperty(ref _rate, value);
            }
        }
        private int _rate;

        public string Etc1
        {
            get => _etc1;
            set => SetProperty(ref _etc1, value);
        }
        private string _etc1 = string.Empty;

        public string Etc2
        {
            get => _etc2;
            set => SetProperty(ref _etc2, value);
        }
        private string _etc2 = string.Empty;

        public string Etc3
        {
            get => _etc3;
            set => SetProperty(ref _etc3, value);
        }
        private string _etc3 = string.Empty;

        public string Etc4
        {
            get => _etc4;
            set => SetProperty(ref _etc4, value);
        }
        private string _etc4 = string.Empty;

        public string Memo
        {
            get => _memo;
            set => SetProperty(ref _memo, value);
        }
        private string _memo = string.Empty;

        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set => SetProperty(ref _releaseDate, value);
        }
        private DateTime _releaseDate = DateTime.MinValue;

        public string ReleaseDateString
        {
            get => _releaseDate.ToString(Constants.Database.DateShortFormat);
            set
            {
                if (DateTime.TryParse(value, out DateTime parsedDate))
                {
                    ReleaseDate = parsedDate;
                }
            }
        }

        public DateTime LastDate
        {
            get => _lastDate;
            set => SetProperty(ref _lastDate, value);
        }
        private DateTime _lastDate = DateTime.MinValue;

        public string LastDateString
        {
            get => _lastDate.ToString(Constants.Database.DateShortFormat);
            set
            {
                if (DateTime.TryParse(value, out DateTime parsedDate))
                {
                    LastDate = parsedDate;
                }
            }
        }
    }
}

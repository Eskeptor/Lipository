// ======================================================================================================
// File Name        : SettingsDataModel.cs
// Project          : Lipository.App  
// Last Update      : 2026.10.08 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using Esk.GearForge.CSUtil;

namespace Lipository.App.Datas
{
    public partial class SettingsDataModel : ObservableObject
    {
        public static SettingsDataModel Model { get => _instance.Value; }
        private static readonly Lazy<SettingsDataModel> _instance = new Lazy<SettingsDataModel>(() => new SettingsDataModel());

        public SettingInfoItem TotalInfo
        {
            get => _totalInfo;
            set
            {
                if (SetProperty(ref _totalInfo, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _totalInfo = new SettingInfoItem();

        public SettingInfoItem ImageInfo
        {
            get => _imageInfo;
            set
            {
                if (SetProperty(ref _imageInfo, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _imageInfo = new SettingInfoItem();

        public SettingInfoItem TitleInfo
        {
            get => _titleInfo;
            set
            {
                if (SetProperty(ref _titleInfo, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _titleInfo = new SettingInfoItem();

        public SettingInfoItem SubTitleInfo
        {
            get => _subTitleInfo;
            set
            {
                if (SetProperty(ref _subTitleInfo, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _subTitleInfo = new SettingInfoItem();

        public SettingInfoItem RateInfo
        {
            get => _rateInfo;
            set
            {
                if (SetProperty(ref _rateInfo, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _rateInfo = new SettingInfoItem();

        public SettingInfoItem Etc1Info
        {
            get => _etc1Info;
            set
            {
                if (SetProperty(ref _etc1Info, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _etc1Info = new SettingInfoItem();

        public SettingInfoItem Etc2Info
        {
            get => _etc2Info;
            set
            {
                if (SetProperty(ref _etc2Info, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _etc2Info = new SettingInfoItem();

        public SettingInfoItem Etc3Info
        {
            get => _etc3Info;
            set
            {
                if (SetProperty(ref _etc3Info, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _etc3Info = new SettingInfoItem();

        public SettingInfoItem Etc4Info
        {
            get => _etc4Info;
            set
            {
                if (SetProperty(ref _etc4Info, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _etc4Info = new SettingInfoItem();

        public SettingInfoItem MemoInfo
        {
            get => _memoInfo;
            set
            {
                if (SetProperty(ref _memoInfo, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _memoInfo = new SettingInfoItem();

        public SettingInfoItem ReleaseDateInfo
        {
            get => _releaseDateInfo;
            set
            {
                if (SetProperty(ref _releaseDateInfo, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _releaseDateInfo = new SettingInfoItem();

        public SettingInfoItem LastDateInfo
        {
            get => _lastDateInfo;
            set
            {
                if (SetProperty(ref _lastDateInfo, value))
                {
                    _isChanged = true;
                }
            }
        }
        private SettingInfoItem _lastDateInfo = new SettingInfoItem();

        public string MediaExtensions
        {
            get => _mediaExtensions;
            set
            {
                if (_mediaExtensions.EqualsOrdinal(value))
                {
                    return;
                }
                if (SetProperty(ref _mediaExtensions, value))
                {
                    _isChanged = true;
                }
            }
        }
        private string _mediaExtensions = string.Empty;

        public string ImageExtensions
        {
            get => _imageExtensions;
            set
            {
                if (_imageExtensions.EqualsOrdinal(value))
                {
                    return;
                }
                if (SetProperty(ref _imageExtensions, value))
                {
                    _isChanged = true;
                }
            }
        }
        private string _imageExtensions = string.Empty;

        public string DefaultImagePath
        {
            get => _defaultImagePath;
            set
            {
                if (_defaultImagePath.EqualsOrdinal(value))
                {
                    return;
                }
                if (SetProperty(ref _defaultImagePath, value))
                {
                    _isChanged = true;
                }
            }
        }
        private string _defaultImagePath = string.Empty;

        public bool IsChanged { get => _isChanged; }
        private bool _isChanged;

        public void LoadData()
        {
            AppSettingsData data = AppSettingsStore.Load();

            if (data.IsFirstRun)
            {
                TitleInfo.Text = "Title: ";
                SubTitleInfo.Text = "SubTitle: ";
                RateInfo.Text = "Rate: ";
                Etc1Info.Text = "Etc1: ";
                Etc2Info.Text = "Etc2: ";
                Etc3Info.Text = "Etc3: ";
                Etc4Info.Text = "Etc4: ";
                MemoInfo.Text = "Memo: ";
                ReleaseDateInfo.Text = "Release Date: ";
                LastDateInfo.Text = "Last Date: ";

                data.TitleInfoText = TitleInfo.Text;
                data.SubTitleInfoText = SubTitleInfo.Text;
                data.RateInfoText = RateInfo.Text;
                data.Etc1InfoText = Etc1Info.Text;
                data.Etc2InfoText = Etc2Info.Text;
                data.Etc3InfoText = Etc3Info.Text;
                data.Etc4InfoText = Etc4Info.Text;
                data.MemoInfoText = MemoInfo.Text;
                data.ReleaseInfoText = ReleaseDateInfo.Text;
                data.LastInfoText = LastDateInfo.Text;
                data.IsFirstRun = false;
                AppSettingsStore.Save(data);
            }
            else
            {
                TitleInfo.Text = data.TitleInfoText;
                SubTitleInfo.Text = data.SubTitleInfoText;
                RateInfo.Text = data.RateInfoText;
                Etc1Info.Text = data.Etc1InfoText;
                Etc2Info.Text = data.Etc2InfoText;
                Etc3Info.Text = data.Etc3InfoText;
                Etc4Info.Text = data.Etc4InfoText;
                MemoInfo.Text = data.MemoInfoText;
                ReleaseDateInfo.Text = data.ReleaseInfoText;
                LastDateInfo.Text = data.LastInfoText;
            }

            TotalInfo.Width = data.TotalInfoWidth;
            TotalInfo.Height = data.TotalInfoHeight;

            ImageInfo.IsVisible = data.ImageInfoVisible;
            ImageInfo.Width = data.ImageInfoWidth;
            ImageInfo.Height = data.ImageInfoHeight;
            ImageInfo.XPos = data.ImageInfoXPos;
            ImageInfo.YPos = data.ImageInfoYPos;

            TitleInfo.IsVisible = data.TitleInfoVisible;
            TitleInfo.XPos = data.TitleInfoXPos;
            TitleInfo.YPos = data.TitleInfoYPos;

            SubTitleInfo.IsVisible = data.SubTitleInfoVisible;
            SubTitleInfo.XPos = data.SubTitleInfoXPos;
            SubTitleInfo.YPos = data.SubTitleInfoYPos;

            RateInfo.IsVisible = data.RateInfoVisible;
            RateInfo.XPos = data.RateInfoXPos;
            RateInfo.YPos = data.RateInfoYPos;

            Etc1Info.IsVisible = data.Etc1InfoVisible;
            Etc1Info.XPos = data.Etc1InfoXPos;
            Etc1Info.YPos = data.Etc1InfoYPos;

            Etc2Info.IsVisible = data.Etc2InfoVisible;
            Etc2Info.XPos = data.Etc2InfoXPos;
            Etc2Info.YPos = data.Etc2InfoYPos;

            Etc3Info.IsVisible = data.Etc3InfoVisible;
            Etc3Info.XPos = data.Etc3InfoXPos;
            Etc3Info.YPos = data.Etc3InfoYPos;

            Etc4Info.IsVisible = data.Etc4InfoVisible;
            Etc4Info.XPos = data.Etc4InfoXPos;
            Etc4Info.YPos = data.Etc4InfoYPos;

            MemoInfo.IsVisible = data.MemoInfoVisible;
            MemoInfo.XPos = data.MemoInfoXPos;
            MemoInfo.YPos = data.MemoInfoYPos;

            ReleaseDateInfo.IsVisible = data.ReleaseInfoVisible;
            ReleaseDateInfo.XPos = data.ReleaseInfoXPos;
            ReleaseDateInfo.YPos = data.ReleaseInfoYPos;

            LastDateInfo.IsVisible = data.LastInfoVisible;
            LastDateInfo.XPos = data.LastInfoXPos;
            LastDateInfo.YPos = data.LastInfoYPos;

            MediaExtensions = data.MediaExtensions;
            ImageExtensions = data.ImageExtensions;

            DefaultImagePath = data.DefaultImagePath;

            _isChanged = false;
        }

        public void SaveData()
        {
            AppSettingsData data = new AppSettingsData
            {
                IsFirstRun = false,

                TotalInfoWidth = TotalInfo.Width,
                TotalInfoHeight = TotalInfo.Height,

                ImageInfoWidth = ImageInfo.Width,
                ImageInfoHeight = ImageInfo.Height,
                ImageInfoXPos = ImageInfo.XPos,
                ImageInfoYPos = ImageInfo.YPos,
                ImageInfoVisible = ImageInfo.IsVisible,

                TitleInfoXPos = TitleInfo.XPos,
                TitleInfoYPos = TitleInfo.YPos,
                TitleInfoVisible = TitleInfo.IsVisible,
                TitleInfoText = TitleInfo.Text,

                SubTitleInfoXPos = SubTitleInfo.XPos,
                SubTitleInfoYPos = SubTitleInfo.YPos,
                SubTitleInfoVisible = SubTitleInfo.IsVisible,
                SubTitleInfoText = SubTitleInfo.Text,

                RateInfoXPos = RateInfo.XPos,
                RateInfoYPos = RateInfo.YPos,
                RateInfoVisible = RateInfo.IsVisible,
                RateInfoText = RateInfo.Text,

                Etc1InfoXPos = Etc1Info.XPos,
                Etc1InfoYPos = Etc1Info.YPos,
                Etc1InfoVisible = Etc1Info.IsVisible,
                Etc1InfoText = Etc1Info.Text,

                Etc2InfoXPos = Etc2Info.XPos,
                Etc2InfoYPos = Etc2Info.YPos,
                Etc2InfoVisible = Etc2Info.IsVisible,
                Etc2InfoText = Etc2Info.Text,

                Etc3InfoXPos = Etc3Info.XPos,
                Etc3InfoYPos = Etc3Info.YPos,
                Etc3InfoVisible = Etc3Info.IsVisible,
                Etc3InfoText = Etc3Info.Text,

                Etc4InfoXPos = Etc4Info.XPos,
                Etc4InfoYPos = Etc4Info.YPos,
                Etc4InfoVisible = Etc4Info.IsVisible,
                Etc4InfoText = Etc4Info.Text,

                MemoInfoXPos = MemoInfo.XPos,
                MemoInfoYPos = MemoInfo.YPos,
                MemoInfoVisible = MemoInfo.IsVisible,
                MemoInfoText = MemoInfo.Text,

                ReleaseInfoXPos = ReleaseDateInfo.XPos,
                ReleaseInfoYPos = ReleaseDateInfo.YPos,
                ReleaseInfoVisible = ReleaseDateInfo.IsVisible,
                ReleaseInfoText = ReleaseDateInfo.Text,

                LastInfoXPos = LastDateInfo.XPos,
                LastInfoYPos = LastDateInfo.YPos,
                LastInfoVisible = LastDateInfo.IsVisible,
                LastInfoText = LastDateInfo.Text,

                MediaExtensions = MediaExtensions,
                ImageExtensions = ImageExtensions,
                DefaultImagePath = DefaultImagePath,
            };
            _isChanged = false;

            AppSettingsStore.Save(data);
        }
    }
}

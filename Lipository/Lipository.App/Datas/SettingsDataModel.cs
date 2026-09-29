// ======================================================================================================
// File Name        : SettingsDataModel.cs
// Project          : Lipository.App  
// Last Update      : 2026.09.29 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

namespace Lipository.App.Datas
{
    public partial class SettingsDataModel : ObservableObject
    {
        public static SettingsDataModel Model { get => _instance.Value; }
        private static readonly Lazy<SettingsDataModel> _instance = new Lazy<SettingsDataModel>(() => new SettingsDataModel());

        public SettingInfoItem TotalInfo
        {
            get => _totalInfo;
            set => SetProperty(ref _totalInfo, value);
        }
        private SettingInfoItem _totalInfo = new SettingInfoItem();

        public SettingInfoItem ImageInfo
        {
            get => _imageInfo;
            set => SetProperty(ref _imageInfo, value);
        }
        private SettingInfoItem _imageInfo = new SettingInfoItem();

        public SettingInfoItem TitleInfo
        {
            get => _titleInfo;
            set => SetProperty(ref _titleInfo, value);
        }
        private SettingInfoItem _titleInfo = new SettingInfoItem();

        public SettingInfoItem SubTitleInfo
        {
            get => _subTitleInfo;
            set => SetProperty(ref _subTitleInfo, value);
        }
        private SettingInfoItem _subTitleInfo = new SettingInfoItem();

        public SettingInfoItem RateInfo
        {
            get => _rateInfo;
            set => SetProperty(ref _rateInfo, value);
        }
        private SettingInfoItem _rateInfo = new SettingInfoItem();

        public SettingInfoItem Etc1Info
        {
            get => _etc1Info;
            set => SetProperty(ref _etc1Info, value);
        }
        private SettingInfoItem _etc1Info = new SettingInfoItem();

        public SettingInfoItem Etc2Info
        {
            get => _etc2Info;
            set => SetProperty(ref _etc2Info, value);
        }
        private SettingInfoItem _etc2Info = new SettingInfoItem();

        public SettingInfoItem Etc3Info
        {
            get => _etc3Info;
            set => SetProperty(ref _etc3Info, value);
        }
        private SettingInfoItem _etc3Info = new SettingInfoItem();

        public SettingInfoItem Etc4Info
        {
            get => _etc4Info;
            set => SetProperty(ref _etc4Info, value);
        }
        private SettingInfoItem _etc4Info = new SettingInfoItem();

        public SettingInfoItem MemoInfo
        {
            get => _memoInfo;
            set => SetProperty(ref _memoInfo, value);
        }
        private SettingInfoItem _memoInfo = new SettingInfoItem();

        public SettingInfoItem ReleaseDateInfo
        {
            get => _releaseDateInfo;
            set => SetProperty(ref _releaseDateInfo, value);
        }
        private SettingInfoItem _releaseDateInfo = new SettingInfoItem();

        public SettingInfoItem LastDateInfo
        {
            get => _lastDateInfo;
            set => SetProperty(ref _lastDateInfo, value);
        }
        private SettingInfoItem _lastDateInfo = new SettingInfoItem();

        public string MediaExtensions
        {
            get => _mediaExtensions;
            set => SetProperty(ref _mediaExtensions, value);
        }
        private string _mediaExtensions = string.Empty;

        public string ImageExtensions
        {
            get => _imageExtensions;
            set => SetProperty(ref _imageExtensions, value);
        }
        private string _imageExtensions = string.Empty;

        public void LoadData()
        {
            if (Properties.Settings.Default.IsFirstRun)
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

                Properties.Settings.Default.TitleInfoText = TitleInfo.Text;
                Properties.Settings.Default.SubTitleInfoText = SubTitleInfo.Text;
                Properties.Settings.Default.RateInfoText = RateInfo.Text;
                Properties.Settings.Default.Etc1InfoText = Etc1Info.Text;
                Properties.Settings.Default.Etc2InfoText = Etc2Info.Text;
                Properties.Settings.Default.Etc3InfoText = Etc3Info.Text;
                Properties.Settings.Default.Etc4InfoText = Etc4Info.Text;
                Properties.Settings.Default.MemoInfoText = MemoInfo.Text;
                Properties.Settings.Default.ReleaseInfoText = ReleaseDateInfo.Text;
                Properties.Settings.Default.LastInfoText = LastDateInfo.Text;
                Properties.Settings.Default.IsFirstRun = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                TitleInfo.Text = Properties.Settings.Default.TitleInfoText;
                SubTitleInfo.Text = Properties.Settings.Default.SubTitleInfoText;
                RateInfo.Text = Properties.Settings.Default.RateInfoText;
                Etc1Info.Text = Properties.Settings.Default.Etc1InfoText;
                Etc2Info.Text = Properties.Settings.Default.Etc2InfoText;
                Etc3Info.Text = Properties.Settings.Default.Etc3InfoText;
                Etc4Info.Text = Properties.Settings.Default.Etc4InfoText;
                MemoInfo.Text = Properties.Settings.Default.MemoInfoText;
                ReleaseDateInfo.Text = Properties.Settings.Default.ReleaseInfoText;
                LastDateInfo.Text = Properties.Settings.Default.LastInfoText;
            }

            TotalInfo.Width = Properties.Settings.Default.TotalInfoSize.Width;
            TotalInfo.Height = Properties.Settings.Default.TotalInfoSize.Height;

            ImageInfo.IsVisible = Properties.Settings.Default.ImageInfoVisible;
            ImageInfo.Width = Properties.Settings.Default.ImageInfoSize.Width;
            ImageInfo.Height = Properties.Settings.Default.ImageInfoSize.Height;
            ImageInfo.XPos = Properties.Settings.Default.ImageInfoPos.X;
            ImageInfo.YPos = Properties.Settings.Default.ImageInfoPos.Y;

            TitleInfo.IsVisible = Properties.Settings.Default.TitleInfoVisible;
            TitleInfo.XPos = Properties.Settings.Default.TitleInfoPos.X;
            TitleInfo.YPos = Properties.Settings.Default.TitleInfoPos.Y;

            SubTitleInfo.IsVisible = Properties.Settings.Default.SubTitleInfoVisible;
            SubTitleInfo.XPos = Properties.Settings.Default.SubTitleInfoPos.X;
            SubTitleInfo.YPos = Properties.Settings.Default.SubTitleInfoPos.Y;

            RateInfo.IsVisible = Properties.Settings.Default.RateInfoVisible;
            RateInfo.XPos = Properties.Settings.Default.RateInfoPos.X;
            RateInfo.YPos = Properties.Settings.Default.RateInfoPos.Y;

            Etc1Info.IsVisible = Properties.Settings.Default.Etc1InfoVisible;
            Etc1Info.XPos = Properties.Settings.Default.Etc1InfoPos.X;
            Etc1Info.YPos = Properties.Settings.Default.Etc1InfoPos.Y;

            Etc2Info.IsVisible = Properties.Settings.Default.Etc2InfoVisible;
            Etc2Info.XPos = Properties.Settings.Default.Etc2InfoPos.X;
            Etc2Info.YPos = Properties.Settings.Default.Etc2InfoPos.Y;

            Etc3Info.IsVisible = Properties.Settings.Default.Etc3InfoVisible;
            Etc3Info.XPos = Properties.Settings.Default.Etc3InfoPos.X;
            Etc3Info.YPos = Properties.Settings.Default.Etc3InfoPos.Y;

            Etc4Info.IsVisible = Properties.Settings.Default.Etc4InfoVisible;
            Etc4Info.XPos = Properties.Settings.Default.Etc4InfoPos.X;
            Etc4Info.YPos = Properties.Settings.Default.Etc4InfoPos.Y;

            MemoInfo.IsVisible = Properties.Settings.Default.MemoInfoVisible;
            MemoInfo.XPos = Properties.Settings.Default.MemoInfoPos.X;
            MemoInfo.YPos = Properties.Settings.Default.MemoInfoPos.Y;

            ReleaseDateInfo.IsVisible = Properties.Settings.Default.ReleaseInfoVisible;
            ReleaseDateInfo.XPos = Properties.Settings.Default.ReleaseInfoPos.X;
            ReleaseDateInfo.YPos = Properties.Settings.Default.ReleaseInfoPos.Y;

            LastDateInfo.IsVisible = Properties.Settings.Default.LastInfoVisible;
            LastDateInfo.XPos = Properties.Settings.Default.LastInfoPos.X;
            LastDateInfo.YPos = Properties.Settings.Default.LastInfoPos.Y;

            MediaExtensions = Properties.Settings.Default.MediaExtensions;
            ImageExtensions = Properties.Settings.Default.ImageExtensions;
        }
    }
}

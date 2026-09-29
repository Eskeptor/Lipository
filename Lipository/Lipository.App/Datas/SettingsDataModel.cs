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
    }
}

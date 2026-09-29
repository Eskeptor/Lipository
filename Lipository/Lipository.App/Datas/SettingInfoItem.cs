// ======================================================================================================
// File Name        : SettingInfoItem.cs
// Project          : Lipository.App
// Last Update      : 2026.09.29 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml;

namespace Lipository.App.Datas
{
    public partial class SettingInfoItem : ObservableObject
    {
        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }
        private int _width = 0;

        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }
        private int _height = 0;

        public int XPos
        {
            get => _xPos;
            set => SetProperty(ref _xPos, value);
        }
        private int _xPos = 0;

        public int YPos
        {
            get => _yPos;
            set => SetProperty(ref _yPos, value);
        }
        private int _yPos = 0;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        private string _title = string.Empty;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
        private string _text = string.Empty;

        public Visibility Visible
        {
            get => _visible;
            set => SetProperty(ref _visible, value);
        }
        private Visibility _visible = Visibility.Visible;

        public int FontSize
        {
            get => _fontSize;
            set => SetProperty(ref _fontSize, value);
        }
        private int _fontSize = 12;

        public bool IsVisible
        {
            get => _visible == Visibility.Visible;
            set => Visible = value ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}

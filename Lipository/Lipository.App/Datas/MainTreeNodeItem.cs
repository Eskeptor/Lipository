// ======================================================================================================
// File Name        : MainTreeNodeItem.cs
// Project          : Lipository.App
// Last Update      : 2026.10.09 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

namespace Lipository.App.Datas
{
    public partial class MainTreeNodeItem : ObservableObject
    {
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        private string _name = string.Empty;
        
        public bool IsExpanded
        {
            get => _isExpanded;
            set => SetProperty(ref _isExpanded, value);
        }
        private bool _isExpanded;

        public object? Tag { get; set; }

        public ObservableCollection<MainTreeNodeItem> Children { get; } = new ObservableCollection<MainTreeNodeItem>();
    }
}

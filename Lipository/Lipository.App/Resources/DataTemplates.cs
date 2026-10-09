// ======================================================================================================
// File Name        : DataTemplates.xaml.cs
// Project          : Lipository.App
// Last Update      : 2026.10.09 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;

using CommunityToolkit.Mvvm.Messaging;

using Lipository.App.Datas;
using Lipository.App.Globals;

namespace Lipository.App.Resources
{
    public sealed partial class DataTemplates : ResourceDictionary
    {
        public DataTemplates()
        {
            InitializeComponent();
        }

        private void Canvas_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (sender is not FrameworkElement { Tag: DatabaseItem item })
            {
                return;
            }
            WeakReferenceMessenger.Default.Send(new RunItemMessage(item));
        }
    }
}

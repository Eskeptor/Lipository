// ======================================================================================================
// File Name        : Messages.cs
// Project          : Lipository.App
// Last Update      : 2026.10.09 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.Messaging.Messages;

using Lipository.App.Datas;

namespace Lipository.App.Globals
{
    public sealed class RunItemMessage(DatabaseItem item) : ValueChangedMessage<DatabaseItem>(item);
}

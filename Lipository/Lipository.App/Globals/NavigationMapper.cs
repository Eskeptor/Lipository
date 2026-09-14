using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lipository.App.Globals
{
    public class NavigationMapper
    {
        /// <summary>
        /// A dictionary that maps page names to their corresponding types and display names. <br/>
        /// Key: Page name (string) <br/>
        /// Value: Tuple containing the page type (Type) and display name (string) <br/>
        /// </summary>
        public static Dictionary<string, (Type, string)> PageMap { get; } = new Dictionary<string, (Type, string)>()
        {
             { $"{Constants.Pages.RootPath}.MainPage", (typeof(Pages.MainPage), "Main") },
             { $"{Constants.Pages.RootPath}.DatabasePage", (typeof(Pages.DatabasePage), "Database") },
             { $"{Constants.Pages.RootPath}.SettingPage", (typeof(Pages.SettingPage), "Settings") }
        };
    }
}

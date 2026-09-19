// ======================================================================================================
// File Name        : Constants.cs
// Project          : Lipository.App
// Last Update      : 2026.09.19 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Esk.GearForge.CSUtil;

namespace Lipository.App.Globals
{
    public static class Constants
    {
        public static class Directories
        {
            public static readonly string Database = "Database";
        }
        public static class Pages
        {
            public static readonly string RootPath = "Lipository.App.Pages";
        }

        public static class Database
        {
            public static readonly string DateShortFormat = "yyyy-MM-dd";
            public static readonly string FileName = "Lipository.db";
            public static readonly string MainTableName = "Lipository";

            public static readonly string DirPath = Path.Combine(FileUtil.GetCurrentPath(FileUtil.EnvironmentTypes.WPF), Directories.Database);
            public static readonly string FullPath = Path.Combine(DirPath, FileName);
        }
    }
}

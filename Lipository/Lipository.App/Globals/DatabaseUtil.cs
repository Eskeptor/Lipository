// ======================================================================================================
// File Name        : DatabaseUtil.cs
// Project          : Lipository.App
// Last Update      : 2026.09.19 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Esk.GearForge.SQLiteUtil.Query;

namespace Lipository.App.Globals
{
    public static class DatabaseUtil
    {
        public static CreateTableQuery MakeCreateTableQuery()
        {
            CreateTableQuery query = new CreateTableQuery(Constants.Database.MainTableName, true);
            query.Add("ID", QueryDataType.Integer, true, true);
            query.Add("ImagePath", QueryDataType.Text);
            query.Add("Title", QueryDataType.Text);
            query.Add("SubTitle", QueryDataType.Text);
            query.Add("DataPath", QueryDataType.Text);
            query.Add("Rate", QueryDataType.Integer);
            query.Add("Etc1", QueryDataType.Text);
            query.Add("Etc2", QueryDataType.Text);
            query.Add("Etc3", QueryDataType.Text);
            query.Add("Etc4", QueryDataType.Text);
            query.Add("Memo", QueryDataType.Text);
            query.Add("ReleaseDate", QueryDataType.Text);
            query.Add("LastDate", QueryDataType.Text);
            return query;
        }
    }
}

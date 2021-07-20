using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteApp.Interfaces
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}

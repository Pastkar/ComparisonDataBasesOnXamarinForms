using Foundation;
using SQLiteApp.Interfaces;
using SQLite.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UIKit;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace SQLite.iOS
{
    class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }
        public string GetDatabasePath(string filename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // папка библиотеки
            var path = Path.Combine(libraryPath, filename);
            return path;
        }
    }
}
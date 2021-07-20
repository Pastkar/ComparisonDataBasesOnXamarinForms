using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLite_APP.Models
{
    public class DBRepository
    {
        SQLiteConnection database;
        static object locker = new object();
        public DBRepository (string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<DataBaseModel>();
        }
        public IEnumerable<DataBaseModel> GetItems()
        {
            lock (locker)
                return database.Table<DataBaseModel>().ToList();
        }
        public DataBaseModel GetItem(int id)
        {
            lock (locker)
                return database.Get<DataBaseModel>(id);
        }
        public int DeleteItem(int id)
        {
            lock (locker)
                return database.Delete<DataBaseModel>(id);
        }
        public int SaveItem(DataBaseModel item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    database.Update(item);
                    return item.Id;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }
        public int DeleteAll()
        {
            lock (locker)
            {
                return database.DeleteAll<DataBaseModel>();
            }
        }
    }

}

using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArmorUp
{
    public class MainTableRepository
    {
        SQLiteConnection database;
        public MainTableRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<MainTable>();
        }

        public int Count
        {
            get
            {
                return database.Table<MainTable>().Count();
            }
        }
        public MainTable[] GetItems()
        {
            return database.Table<MainTable>().ToArray();
        }
        public MainTable GetItem(int id)
        {
            return database.Get<MainTable>(id);
        }
        public int DeleteItem(int id)
        {
            var item = this.GetItem(id);
            
            File.Delete(Path.Combine(DBSaverLoader.documentsPath, item.StringID + ".db"));
            File.Delete(Path.Combine(DBSaverLoader.documentsPath, item.StringID + ".json"));
            return database.Delete<MainTable>(id);
        }

        public int SaveItem(MainTable item)
        {
            if (item.ID != 0)
            {
                database.Update(item);
                return item.ID;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}

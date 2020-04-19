using SQLite;
using System;
using System.Collections.Generic;
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
        public IEnumerable<MainTable> GetItems()
        {
            return database.Table<MainTable>().ToList();
        }
        public MainTable GetItem(int id)
        {
            return database.Get<MainTable>(id);
        }
        public int DeleteItem(int id)
        {
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

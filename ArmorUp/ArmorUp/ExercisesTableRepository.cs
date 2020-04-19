using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ArmorUp
{
    class ExercisesTableRepository
    {
        SQLiteConnection database;
        public ExercisesTableRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);            
        }

        public void CreateTable()
        {
            database.CreateTable<ExercisesTable>();
        }
        public IEnumerable<ExercisesTable> GetItems()
        {
            return database.Table<ExercisesTable>().ToList();
        }
        public ExercisesTable GetItem(int id)
        {
            return database.Get<ExercisesTable>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<ExercisesTable>(id);
        }

        public int SaveItem(ExercisesTable item)
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

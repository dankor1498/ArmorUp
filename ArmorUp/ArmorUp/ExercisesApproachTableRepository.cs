using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ArmorUp
{
    class ExercisesApproachTableRepository 
    {
        SQLiteConnection database;
        public ExercisesApproachTableRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<ExercisesApproachTable>();
        }

        public int Count
        {
            get
            {
                return database.Table<ExercisesApproachTable>().Count();
            }
        }

        public void DeleteFirst()
        {            
            database.Delete<ExercisesApproachTable>(database.Table<ExercisesApproachTable>().First().ID);            
        }

        public ExercisesApproachTable[] GetItems()
        {
            return database.Table<ExercisesApproachTable>().ToArray();
        }
        public ExercisesApproachTable GetItem(int id)
        {
            return database.Get<ExercisesApproachTable>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<ExercisesApproachTable>(id);
        }

        public int SaveItem(ExercisesApproachTable item)
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

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ArmorUp
{
    class ExercisesApproachTableRepository 
    {
        SQLiteConnection database;
        public int StartPosition = 1;
        private int count;

        public ExercisesApproachTableRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<ExercisesApproachTable>();
            count = database.Table<ExercisesApproachTable>().Count();
            if (count >= 1)
                StartPosition = database.Table<ExercisesApproachTable>().First().ID;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void DeleteFirst()
        {
            database.Delete<ExercisesApproachTable>(StartPosition);
            StartPosition++;
            count--;
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
            count--;
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
                count++;
                return database.Insert(item);
            }
        }
    }
}

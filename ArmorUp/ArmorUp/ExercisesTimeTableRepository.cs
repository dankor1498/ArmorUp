using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmorUp
{
    class ExercisesTimeTableRepository
    {
        SQLiteConnection database;
        public int StartPosition = 1;
        private int count;

        public ExercisesTimeTableRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<ExercisesTimeTable>();
            count = database.Table<ExercisesTimeTable>().Count();
            if (count >= 1)
                StartPosition = database.Table<ExercisesTimeTable>().First().ID;
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
            database.Delete<ExercisesTimeTable>(StartPosition);
            StartPosition++;
            count--;
        }

        public ExercisesTimeTable[] GetItems()
        {
            return database.Table<ExercisesTimeTable>().ToArray();
        }
        public ExercisesTimeTable GetItem(int id)
        {
            return database.Get<ExercisesTimeTable>(id);
        }
        public int DeleteItem(int id)
        {
            count--;
            return database.Delete<ExercisesTimeTable>(id);
        }

        public int SaveItem(ExercisesTimeTable item)
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

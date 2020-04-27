using SQLite;

namespace ArmorUp
{
    internal class ExercisesCountTableRepository 
    {
        private SQLiteConnection database;
        public int StartPosition = 1;
        private int count;

        public ExercisesCountTableRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<ExercisesCountTable>();
            count = database.Table<ExercisesCountTable>().Count();
            if (count >= 1)
                StartPosition = database.Table<ExercisesCountTable>().First().ID;
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
            database.Delete<ExercisesCountTable>(StartPosition);
            StartPosition++;
            count--;
        }

        public ExercisesCountTable[] GetItems()
        {
            return database.Table<ExercisesCountTable>().ToArray();
        }

        public ExercisesCountTable GetItem(int id)
        {
            return database.Get<ExercisesCountTable>(id);
        }

        public int DeleteItem(int id)
        {
            count--;
            return database.Delete<ExercisesCountTable>(id);
        }

        public int SaveItem(ExercisesCountTable item)
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
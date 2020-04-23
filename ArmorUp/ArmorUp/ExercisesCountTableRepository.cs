using SQLite;

namespace ArmorUp
{
    internal class ExercisesCountTableRepository 
    {
        private SQLiteConnection database;

        public ExercisesCountTableRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<ExercisesCountTable>();
        }

        public int Count
        {
            get
            {
                return database.Table<ExercisesCountTable>().Count();
            }
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
                return database.Insert(item);
            }
        }
    }
}
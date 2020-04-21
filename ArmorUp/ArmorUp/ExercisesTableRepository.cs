using SQLite;

namespace ArmorUp
{
    internal class ExercisesTableRepository
    {
        private SQLiteConnection database;

        public ExercisesTableRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<ExercisesTable>();
        }

        public int Count
        {
            get
            {
                return database.Table<ExercisesTable>().Count();
            }
        }

        public ExercisesTable[] GetItems()
        {
            return database.Table<ExercisesTable>().ToArray();
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
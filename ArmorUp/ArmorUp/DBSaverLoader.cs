using System;
using System.IO;
using System.Runtime.Serialization.Json;
using SQLite;

//@"C:\Users\Danyil Korotych\Desktop\ConsoleApp1\JSON\"

namespace ArmorUp
{
    public class DBSaverLoader
    {
        static DataContractJsonSerializer json_formatter = new DataContractJsonSerializer(typeof(Exercises));
        public static string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        static public void SAVE_EXERCISE(Exercises exercises, MainTableRepository Database)
        {
            string stringID = Guid.NewGuid().ToString();
            Database.SaveItem(new MainTable() { StringID = stringID, Name = exercises.Name });

            ExercisesTableRepository exercisesFileRepository = new ExercisesTableRepository(documentsPath + stringID + ".db");

            var path = Path.Combine(documentsPath, stringID + ".json");

            using (var file = new FileStream(path, FileMode.Create))
                json_formatter.WriteObject(file, exercises);
        }

        static public ExercisesCount LOAD_EXERCISE(int id, MainTableRepository Database)
        {
            var item = Database.GetItem(id);
            var path = Path.Combine(documentsPath, item.StringID + ".json");

            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                var exercises = json_formatter.ReadObject(file) as ExercisesCount;
                if (exercises != null)
                    return exercises;
            }
            return null;
        }
    }
}

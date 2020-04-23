using System;
using System.IO;
using System.Runtime.Serialization.Json;
using SQLite;

namespace ArmorUp
{
    public class DBSaverLoader
    {
        static DataContractJsonSerializer json_formatter = new DataContractJsonSerializer(typeof(Exercises));
        public static string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        static public void SAVE_EXERCISE(Exercises exercises, MainTableRepository Database)
        {
            string stringID = Guid.NewGuid().ToString();

            if(exercises is ExercisesCount)
            {
                Database.SaveItem(new MainTable() { StringID = stringID, Type = (byte)App.TypeExercises.Count, Name = exercises.Name, Purpose = exercises.PurposeToString() });
            }
            else if(exercises is ExercisesApproach)
            {
                Database.SaveItem(new MainTable() { StringID = stringID, Type = (byte)App.TypeExercises.Approach, Name = exercises.Name, Purpose = exercises.PurposeToString() });
            }

            var path = Path.Combine(documentsPath, stringID + ".json");

            using (var file = new FileStream(path, FileMode.Create))
                json_formatter.WriteObject(file, exercises);
        }

        static public object LOAD_EXERCISE(int id, MainTableRepository Database)
        {
            var item = Database.GetItem(id);
            var path = Path.Combine(documentsPath, item.StringID + ".json");

            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {                
                return json_formatter.ReadObject(file);
            }
        }

        static public void UPDATE_EXERCISE(int id, Exercises exercises, MainTableRepository Database)
        {
            var item = Database.GetItem(id);
            if (exercises is ExercisesCount)
            {
                Database.SaveItem(new MainTable() { ID = id, Name = exercises.Name, StringID = item.StringID, Purpose = exercises.PurposeToString(), Type = (byte)App.TypeExercises.Count });
            }
            else if (exercises is ExercisesApproach)
            {
                Database.SaveItem(new MainTable() { ID = id, Name = exercises.Name, StringID = item.StringID, Purpose = exercises.PurposeToString(), Type = (byte)App.TypeExercises.Approach });
            }            
            var path = Path.Combine(documentsPath, item.StringID + ".json");

            using (var file = new FileStream(path, FileMode.Create))
                json_formatter.WriteObject(file, exercises);
        }
    }
}

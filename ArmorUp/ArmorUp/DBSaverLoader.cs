using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ArmorUp
{
    class DBSaverLoader
    {
        public void SAVE_USER(ExercisesDB exercises_List)
        {
            var json_formatter = new DataContractJsonSerializer(typeof(ExercisesDB));

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, "ExercisesList.json");

            using (var file = new FileStream(path, FileMode.Create))
                json_formatter.WriteObject(file, exercises_List);
        }
        public ExercisesDB LOAD_USER()
        {
            var json_formatter = new DataContractJsonSerializer(typeof(ExercisesDB));

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, "ExercisesList.json");

            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                var user_list = json_formatter.ReadObject(file) as ExercisesDB;
                if (user_list != null)
                    return user_list;
            }
            return null;
        }
    }
}

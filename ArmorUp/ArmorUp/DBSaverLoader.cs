using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ArmorUp
{
    class DBSaverLoader
    {
        public void SAVE_USER(ExercisesDB exercises_List)
        {
            var json_formatter = new DataContractJsonSerializer(typeof(ExercisesDB));

            using (var file = new FileStream("ExercisesList.json", FileMode.Create))
                json_formatter.WriteObject(file, exercises_List);
        }
        public ExercisesDB LOAD_USER()
        {
            var json_formatter = new DataContractJsonSerializer(typeof(ExercisesDB));

            using (var file = new FileStream("ExercisesList.json", FileMode.OpenOrCreate))
            {
                var user_list = json_formatter.ReadObject(file) as ExercisesDB;
                if (user_list != null)
                    return user_list;
            }
            return null;
        }
    }
}

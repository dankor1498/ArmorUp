using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ArmorUp
{
    [DataContract]
    class ExercisesDB
    {
        [DataMember]
        public List<Exercises> ExercisesList = new List<Exercises>();
        [DataMember]
        public static ExercisesDB CurrentExercisesList;
    }
}

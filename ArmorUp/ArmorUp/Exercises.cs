using System;
using System.Runtime.Serialization;

namespace ArmorUp
{
    [DataContract]
    [KnownType(typeof(ExercisesCount))]
    public abstract class Exercises
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Information { get; set; }
        [DataMember]
        public string LinkName { get; set; }
        [DataMember]
        public string LinkURL { get; set; }

        public abstract string PurposeToString();
        public static int CurrentExercisesId { get; set; }
        public virtual string PrintExercises()//метод для тесту
        {
            return String.Format($"{this.Name}\n{this.Information}" +
                $"\n{this.LinkName} - {this.LinkURL}\n");
        }
    }
}

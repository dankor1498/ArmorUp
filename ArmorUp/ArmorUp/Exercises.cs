﻿using System;
using System.Runtime.Serialization;

namespace ArmorUp
{
    [DataContract]
    [KnownType(typeof(ExercisesCount))]
    public class Exercises
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Information { get; set; }
        [DataMember]
        public string LinkName { get; set; }
        [DataMember]
        public string LinkURL { get; set; }
        public static int CurrentExId { get; set; }
        public static Exercises CurrentExercises { get; set; }

        public virtual string PrintExercises()//метод для тесту
        {
            return String.Format($"{this.Name}\n{this.Information}" +
                $"\n{this.LinkName} - {this.LinkURL}\n");
        }
    }
}

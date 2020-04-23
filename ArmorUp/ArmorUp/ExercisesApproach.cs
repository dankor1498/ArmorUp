using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ArmorUp
{
    [DataContract]
    public class ExercisesApproach : Exercises
    {
        [DataMember]
        public List<int> ApproachList { get; set; }

        public override string PurposeToString()
        {
            return string.Join("/", this.ApproachList);
        }

        public override string PrintExercises()
        {
            return base.PrintExercises() + "Ціль - " + string.Join("/", this.ApproachList);
        }
    }
}

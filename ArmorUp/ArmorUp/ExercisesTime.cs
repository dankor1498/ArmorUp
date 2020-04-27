using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ArmorUp
{
    [DataContract]
    class ExercisesTime : Exercises
    {
        [DataMember]
        public TimeSpan Time { get; set; }
        public override string PurposeToString()
        {
            return this.Time.TotalSeconds.ToString();
        }
    }
}

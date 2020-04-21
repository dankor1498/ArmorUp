using System.Runtime.Serialization;

namespace ArmorUp
{
    [DataContract]
    public class ExercisesCount : Exercises
    {
        [DataMember]
        public int Purpose { get; set; }

        public override string PurposeToString()
        {
            return this.Purpose.ToString();
        }

        public override string PrintExercises()
        {
            return base.PrintExercises() + "Ціль - " + this.Purpose;
        }
    }
}

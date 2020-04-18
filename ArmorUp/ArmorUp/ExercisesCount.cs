using System;
using System.Collections.Generic;
using System.Text;

namespace ArmorUp
{
    public class ExercisesCount : Exercises
    {
        public int Purpose { get; set; }

        public override string PrintExercises()
        {
            return base.PrintExercises() + "Ціль - " + this.Purpose;
        }
    }
}

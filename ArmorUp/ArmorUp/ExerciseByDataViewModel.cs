using System;
using System.Collections.Generic;
using System.Text;

namespace ArmorUp
{
    class ExerciseByDataViewModel
    {
        public List<ExerciseInfoByDate> exerciseInfoByDates { get; set; }
        public static List<ExerciseInfoByDate> exerciseInfoByDatesCopy = new List<ExerciseInfoByDate>();
        public ExerciseByDataViewModel()
        {
            exerciseInfoByDates = exerciseInfoByDatesCopy;
        }
    }
}

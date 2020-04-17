using System;
using System.Collections.Generic;
using System.Text;

namespace ArmorUp
{
    public class Exercises
    {
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public int Percent { get; set; }
        public string Sucsess { get; set; }
        public static Exercises CurrentExercises { get; set; }
        public Exercises() { }
        public Exercises(string Name, string ImageSource, int Percent, string Sucsess)
        {
            this.Name = Name;
            this.ImageSource = ImageSource;
            this.Percent = Percent;
            this.Sucsess = Sucsess;
        }
    }
}

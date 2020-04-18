using System;
using System.Collections.Generic;
using System.Text;

namespace ArmorUp
{
    public abstract class Exercises
    {
        public string Name { get; set; }
        public string Information { get; set; }
        public string LinkName { get; set; }
        public string LinkURL { get; set; }

        public virtual string PrintExercises()//метод для тесту
        {
            return String.Format($"{this.Name}\n{this.Information}" +
                $"\n{this.LinkName} - {this.LinkURL}\n");
        }
    }
}

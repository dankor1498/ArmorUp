using System;
using System.Collections.Generic;
using System.Text;

namespace ArmorUp
{
    public static class ExercisesTest
    {
        public static List<Exercises> exercisesTest = new List<Exercises>()
        {
            new ExercisesCount { Name = "Підтягування", Information = "Важка вправа", LinkName= "YouTube", LinkURL="https://www.youtube.com/", Purpose = 15 },
            new ExercisesCount { Name = "Підтягування широким хватом", Information = "Легка вправа", LinkName= "YouTube", LinkURL="https://www.youtube.com/", Purpose = 25 },
            new ExercisesCount { Name = "Підтягування вузьким хватом", Information = "Робити спочатку розминку", LinkName= "YouTube", LinkURL="https://www.youtube.com/", Purpose = 10 },
            new ExercisesCount { Name = "Підтягування на біцепс", Information = "Перева 5 хвилин", LinkName= "YouTube", LinkURL="https://www.youtube.com/", Purpose = 30 },
            new ExercisesCount { Name = "Віджимання", Information = "Спину тримати рівно", LinkName= "YouTube", LinkURL="https://www.youtube.com/", Purpose = 27 },
            new ExercisesCount { Name = "Польот Супермена", Information = "Опускатись максимально низько до підлоги", LinkName= "Instagram", LinkURL="https://www.instagram.com/?hl=uk", Purpose = 12 }
        };
    }
}

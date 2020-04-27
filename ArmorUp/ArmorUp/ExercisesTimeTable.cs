using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmorUp
{
    class ExercisesTimeTable
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Count { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ArmorUp
{
    public class ExercisesApproachTable
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string Count { get; set; }
    }
}

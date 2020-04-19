using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace ArmorUp
{
    public class MainTable
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public string StringID { get; set; }
        public string Name { get; set; }
    }
}

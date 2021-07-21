using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteApplication.Models
{
    [Table("Friends")]
    public class DataBaseModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

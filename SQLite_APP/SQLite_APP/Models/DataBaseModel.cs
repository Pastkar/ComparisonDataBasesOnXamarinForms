using SQLite_APP;
using SQLite;

namespace SQLite_APP.Models
{
    [Table("Friends")]
    public class DataBaseModel 
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

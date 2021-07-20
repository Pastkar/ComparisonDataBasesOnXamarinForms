using System;
using System.Collections.Generic;
using System.Text;

namespace RealmExample.Models
{
    class DataBaseModel
    {
        public string Name { get; set; }
        public DataBaseModel(string name)
        {
            Name = name;
        }
    }
}

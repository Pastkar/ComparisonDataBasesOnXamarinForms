﻿using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealmApp.Models
{
    public class Model : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
    }
}

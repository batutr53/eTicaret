﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Models
{
    public class UserRole:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

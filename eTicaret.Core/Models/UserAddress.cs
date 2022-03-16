using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Models
{
    public class UserAddress:BaseEntity
    {
        public string Name { get; set; }
        public string Descr { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}

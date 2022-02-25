using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Models
{
    public class Order:BaseEntity
    {
        public string Number { get; set; }
        public string Satus { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<OrderDetail> OrderDetails{ get; set; }

    }
}

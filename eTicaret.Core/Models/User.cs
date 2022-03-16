
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Core.Models
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string FullName { get; set; }
        public string TelNumber { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public string Confirmation { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public List<UserAddress> UserAddresses { get; set; }
        public List<Order> Orders { get; set; }
    }
}
